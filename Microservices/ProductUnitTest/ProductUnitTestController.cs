using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Aspect.ProductAPI.Entities;
using Aspect.ProductAPI.Repository.ProductRepository;

public class ProductServiceTests
{
    [Fact]
    public async Task GetAll_ReturnsNull_WhenMockRepositoryIsNull()
    {
        // Arrange
        Mock<IProductRepository> mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.GetAll()).Returns(Task.FromResult<IEnumerable<Product>>(null));

        // Act
        var result = await mockRepository.Object.GetAll();

        // Assert
        Assert.Null(result);
    }
}
