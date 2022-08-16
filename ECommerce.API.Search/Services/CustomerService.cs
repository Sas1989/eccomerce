using ECommerce.API.Search.Interfaces;
using ECommerce.API.Search.Models;
using System.Net.Http;
using System.Text.Json;

namespace ECommerce.API.Search.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly ILogger<CustomerService> logger;

        public CustomerService(IHttpClientFactory clientFactory, ILogger<CustomerService> logger)
        {
            this.clientFactory = clientFactory;
            this.logger = logger;
        }
        public async Task<(bool isSuccess, Customer customer, string ErrorMessage)> GetCustomerAsync(int CustomerId)
        {
            try
            {
                var client = clientFactory.CreateClient("CustomerService");
                var response = await client.GetAsync($"api/customers/{CustomerId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<Customer>(content, options);
                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false,null,ex.Message);
            }
        }
    }
}
