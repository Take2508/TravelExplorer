namespace Domain.Destinations;

public interface IDestinationRepository
{
    Task<Destination?> GetByIdAsync(DestinationId id);
    Task<bool> ExistsAsync(DestinationId id);
    Task Add(Destination destination);
    Task<List<Destination>> GetAll();
    void Update(Destination destination);

    void Delete(Destination destination);
}