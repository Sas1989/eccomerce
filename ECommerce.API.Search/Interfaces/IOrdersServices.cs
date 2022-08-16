using ECommerce.API.Search.Models;

namespace ECommerce.API.Search.Interfaces
{
    public interface IOrdersServices
    {
        Task <(bool IsSuccess, IEnumerable<Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId);
    }
}
