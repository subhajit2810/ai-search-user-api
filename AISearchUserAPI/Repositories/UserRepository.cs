using AISearchUserAPI.Models;

namespace AISearchUserAPI.Repositories;

public class UserRepository : IUserRepository
{
    private static List<User> _users = new()
    {
        new() { Id = 1, Name = "Subhajit Tewary", Email = "subhajit@gmail.com" },
        new() { Id = 2, Name = "User 2", Email = "user2@example.com" },
        new() { Id = 3, Name = "User 3", Email = "user3@example.com" }
    };

    public Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return Task.FromResult<IEnumerable<User>>(_users);
    }

    public Task<User?> GetUserByIdAsync(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        return Task.FromResult(user);
    }

    public Task<User> CreateUserAsync(User user)
    {
        user.Id = _users.Max(u => u.Id) + 1;
        _users.Add(user);
        return Task.FromResult(user);
    }

    public Task<User?> UpdateUserAsync(int id, User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == id);
        if (existingUser == null)
            return Task.FromResult<User?>(null);

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        return Task.FromResult<User?>(existingUser);
    }

    public Task<bool> DeleteUserAsync(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return Task.FromResult(false);

        _users.Remove(user);
        return Task.FromResult(true);
    }
}
