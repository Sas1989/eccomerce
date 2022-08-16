using ECommerce.API.Search.Interfaces;

namespace ECommerce.API.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrdersServices ordersServices;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;

        public SearchService(IOrdersServices ordersServices,IProductService productService,ICustomerService customerService)
        {
            this.ordersServices = ordersServices;
            this.productService = productService;
            this.customerService = customerService;
        }
        public async Task<(bool isSuccess, dynamic SearchResult)> SearchAsync(int CusomerId)
        {
            var ordersResult = await ordersServices.GetOrdersAsync(CusomerId);
            var productResult = await productService.GetProductAsync();
            var customer = await customerService.GetCustomerAsync(CusomerId);
            if (ordersResult.IsSuccess)
            {
                foreach(var order in ordersResult.Orders)
                {
                    foreach(var item in order.Items)
                    {
                        item.ProductName = productResult.IsSuccess ? productResult.Products.FirstOrDefault(p => p.Id == item.ProductId)?.Name : "Product Information is not available" ;
                    }

                }
                var result = new
                {
                    Customer = customer.customer,
                    Orders = ordersResult.Orders
                };
                return (true, result);
            }
            return (false, null);
        }
    }
}
