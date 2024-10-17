using Resources.Enums;
using Resources.Models;
using Resources.Services;
using Xunit;

namespace Resources.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void AddToList_ShouldReturnSuccess_WhenProductIsAddedToList()
        {
            //Arrange
            Product product = new Product { ProductName = "Kaffe", ProductPrice = "24,90", ProductId = Guid.NewGuid().ToString() };
            ProductService productService = new ProductService();

            //Act
            ResultStatus result = productService.AddProduct(product);
            var productList = productService.GetAllProducts();


            //Assert
            Assert.Equal(ResultStatus.Success, result);
            Assert.Single(productList);
        }
    }
}
