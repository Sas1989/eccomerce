using ECommerce.API.Orders.Models;

namespace ECommerce.API.Orders.Interfaces
{
    public interface IOrderProviders
    {
        Task<(bool IsSuccess, IEnumerable<Order> Orders, string ErrorMessage)> GetOrderAsync(int customerId);
    }
}
