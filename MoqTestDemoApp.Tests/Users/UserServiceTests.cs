using Moq;
using MoqTestDemoApp.Interfaces;
using MoqTestDemoApp.IRepositories;
using MoqTestDemoApp.Models;
using MoqTestDemoApp.Services;
using System.Linq.Expressions;

namespace TestProject2;

public class UserServiceTests
{
    private readonly IUserService userService;
    private readonly Mock<IRepository<User>> userRepositoryMock;
    public UserServiceTests()
    {
        this.userRepositoryMock = new Mock<IRepository<User>>();
        this.userService = new UserService(userRepositoryMock.Object);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnCreatedUser()
    {
        // Arrange
        var user = new UserCreationDto
        {
            FirstName = "John",
            LastName = "Doe"
        };

        var expectedUser = new User
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };

        userRepositoryMock.Setup(r => r.InsertAsync(It.IsAny<User>()))
            .ReturnsAsync(expectedUser);

        // Act
        var result = await this.userService.AddAsync(user);


        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedUser, result);
        Assert.Equal(expectedUser.Id, result.Id);

        userRepositoryMock.Verify(r => r.InsertAsync(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnValidUser()
    {
        // Arrange
        long userId = 1;

        var expectedUser = new User { Id = userId };

        userRepositoryMock.Setup(r => r.SelectAsync(It.IsAny<Expression<Func<User, bool>>>()))
            .ReturnsAsync(expectedUser);

        // Act
        var result = await this.userService.GetByIdAsync(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedUser, result);
        Assert.Equal(userId, result.Id);

        userRepositoryMock.Verify(r => r.SelectAsync(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
    }
}
