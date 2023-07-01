using Domain.ValueObjects;

namespace Domain.Destinations;

public sealed class Destination
{
    public Destination(DestinationId id, string name, string description, string ubication, bool active)
    {
        Id = id;
        Name = name;
        Description = description;
        Ubication = ubication;
        Active = active;
    }

    private Destination()
    {

    }

    public DestinationId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Ubication { get; private set; } = string.Empty;
    public bool Active { get; private set; }

    public static Destination UpdateDestination(Guid id, string name, string description, string ubication, bool active)
    {
        return new Destination(new DestinationId(id), name, description, ubication, active);
    }
}