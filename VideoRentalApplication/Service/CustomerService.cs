using Microsoft.EntityFrameworkCore;
using VideoRentalApplication.Models;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<Customer> CreateCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(int id, Customer customer);
    Task<bool> DeleteCustomerAsync(int id);
}

public class CustomerService : ICustomerService
{
    private readonly VideoRentalDbContext _dbContext;

    public CustomerService(VideoRentalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        if (customer == null)
        {
            throw new ArgumentException("Customer not found", nameof(id));
        }

        return customer;
    }


    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> UpdateCustomerAsync(int id, Customer customer)
    {
        var existingCustomer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        if (existingCustomer == null)
        {
            throw new ArgumentException("Customer not found", nameof(id));
        }

        existingCustomer.Name = customer.Name;
        existingCustomer.EmailId = customer.EmailId;

        await _dbContext.SaveChangesAsync();
        return existingCustomer;
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        if (customer == null)
        {
            return false;
        }

        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
