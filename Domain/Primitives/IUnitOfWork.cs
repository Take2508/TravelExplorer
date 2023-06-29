namespace Domain.Primitives;

public interface IUnitOfWork
{
    Task<int> SavesChangesAsync(CancellationToken cancellationToken =default);
}