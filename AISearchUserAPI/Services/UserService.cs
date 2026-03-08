using AISearchUserAPI.Models;
using AISearchUserAPI.Repositories;

namespace AISearchUserAPI.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("User ID must be greater than 0");

        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name))
            throw new ArgumentException("User name is required");

        if (string.IsNullOrWhiteSpace(user.Email))
            throw new ArgumentException("User email is required");

        return await _userRepository.CreateUserAsync(user);
    }

    public async Task<User?> UpdateUserAsync(int id, User user)
    {
        if (id <= 0)
            throw new ArgumentException("User ID must be greater than 0");

        return await _userRepository.UpdateUserAsync(id, user);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("User ID must be greater than 0");

        return await _userRepository.DeleteUserAsync(id);
    }
}
