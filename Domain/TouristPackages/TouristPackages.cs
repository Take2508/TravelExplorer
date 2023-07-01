using Domain.Destinations;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.TouristPackages;

public sealed class TouristPackage : AgregateRoot
{
    private readonly List<LineItem> _lineItems = new();
    private TouristPackage()
    {

    }

    public TouristPackageId Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime TravelDate { get; private set; }
    public Money Price { get; private set; }
    public IReadOnlyList<LineItem> LineItems => _lineItems.AsReadOnly();

    public static TouristPackage Create(string name, string description, DateTime traveldate, Money price)
    {
        var touristpackage = new TouristPackage
        {
            Id = new TouristPackageId(Guid.NewGuid()),
            Name = name,
            Description = description,
            TravelDate = traveldate,
            Price = price
        };

        return touristpackage;
    }

    public void Add(DestinationId destinationId)
    {
        var LineItem = new LineItem(new LineItemId(Guid.NewGuid()), Id, destinationId);

        _lineItems.Add(LineItem);
    }
    public void Update(string name, string description, DateTime traveldate, Money price)
    {
        Name = name;
        Description = description;
        TravelDate = traveldate;
        Price = price;
    }


    public void UpdateLineItem(LineItemId lineItemId, DestinationId destinationId)
    {
        var lineItem = _lineItems.FirstOrDefault(li => li.Id == lineItemId);
        if (lineItem != null)
        {
            lineItem.Update(destinationId);
        }
    }
    public void RemoveLineItem(LineItemId lineItemId, ITouristPackageRepository touristPackageRepository)
    {
        if (touristPackageRepository.HasOneLineItem(this))
        {
            return;
        }

        var lineItem = _lineItems.FirstOrDefault(li => li.Id == lineItemId);

        if (lineItem == null)
        {
            return;
        }

        _lineItems.Remove(lineItem);
    }

}