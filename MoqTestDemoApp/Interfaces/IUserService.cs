using MoqTestDemoApp.Models;

namespace MoqTestDemoApp.Interfaces;

public interface IUserService
{
    Task<User> AddAsync(UserCreationDto dto);
    Task<User> ModifyAsync(long id, UserCreationDto dto);
    Task<bool> DeleteAsync(long id);
    Task<User> GetByIdAsync(long id);
    Task<IEnumerable<User>> GetAllAsync();
}
