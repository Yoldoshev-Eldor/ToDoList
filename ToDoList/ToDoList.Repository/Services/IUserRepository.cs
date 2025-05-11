using ToDoList.DataAccess.Entities;

namespace ToDoList.Repository.Services;

public interface IUserRepository
{
    Task<long> InsertUserAsync(User user);
    Task<User> SelectUserByIdAsync(long id);
    Task<User> SelectUserByUserNameAsync(string userName);
}