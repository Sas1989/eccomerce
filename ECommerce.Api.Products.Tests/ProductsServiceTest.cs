using AutoMapper;
using ECommerce.API.Products.Db;
using ECommerce.API.Products.Profile;
using ECommerce.API.Products.Providers.Products;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Products.Tests
{
    public class ProductsServiceTest
    {
        [Fact]
        public async void GetProductsReturnsAllProducts()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(nameof(GetProductsReturnsAllProducts)).Options;
            var dbContext = new ProductDbContext(options);
            CreateProducts(dbContext);
            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);
            var productsProvider = new ProductsProvider(dbContext, null, mapper);

            var product = await productsProvider.GetProductsAsync();

            Assert.True(product.IsSuccess);
            Assert.True(product.Products.Any());
            Assert.Null(product.ErrorMessage);
        }
        [Fact]
        public async void GetProductRetursProductUsingValidId()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(nameof(GetProductRetursProductUsingValidId)).Options;
            var dbContext = new ProductDbContext(options);
            CreateProducts(dbContext);
            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);
            var productsProvider = new ProductsProvider(dbContext, null, mapper);

            var product = await productsProvider.GetProductAsync(1);

            Assert.True(product.IsSuccess);
            Assert.NotNull(product.Product);
            Assert.True(product.Product.Id ==1);
            Assert.Null(product.ErrorMessage);
        }
        [Fact]
        public async void GetProductRetursProductUsingInValidId()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(nameof(GetProductRetursProductUsingInValidId)).Options;
            var dbContext = new ProductDbContext(options);
            CreateProducts(dbContext);
            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);
            var productsProvider = new ProductsProvider(dbContext, null, mapper);

            var product = await productsProvider.GetProductAsync(-1);

            Assert.False(product.IsSuccess);
            Assert.Null(product.Product);
            Assert.NotNull(product.ErrorMessage);
        }

        private void CreateProducts(ProductDbContext dbContext)
        {
            for(int i = 1; i < 11; i++)
            {
                dbContext.Products.Add(new Product
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString(),
                    Inventory = 1 + 10,
                    Price = (decimal)(i*3.14)
                }); 
            }

            dbContext.SaveChanges();
        }
    }
}