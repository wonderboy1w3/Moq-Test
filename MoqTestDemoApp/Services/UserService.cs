using MoqTestDemoApp.Models;
using MoqTestDemoApp.Interfaces;
using MoqTestDemoApp.IRepositories;

namespace MoqTestDemoApp.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> repository;
    public UserService(IRepository<User> repository)
    {
        this.repository = repository;
    }

    public async Task<User> AddAsync(UserCreationDto dto)
    {
        User user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
        };

        User createdUser = await this.repository.InsertAsync(user);
        return createdUser;
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByIdAsync(long id)
    {
        return await this.repository.SelectAsync(user => user.Id == id);
    }

    public Task<User> ModifyAsync(long id, UserCreationDto dto)
    {
        throw new NotImplementedException();
    }
}
