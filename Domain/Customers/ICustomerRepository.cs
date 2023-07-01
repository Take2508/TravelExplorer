namespace Domain.Customers;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAll();
    Task<bool> ExistsAsync(CustomerId id);
    Task<Customer?> GetByIdAsync(CustomerId id);
    Task Add(Customer customer);
    void Update(Customer customer);
    void Delete(Customer customer);
}