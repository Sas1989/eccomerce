using ECommerce.API.Search.Models;

namespace ECommerce.API.Search.Interfaces
{
    public interface ICustomerService
    {
        Task<(bool isSuccess, Customer customer, string ErrorMessage)> GetCustomerAsync(int CustomerId);
    }
}
