using FreshThreads.DTO;

namespace FreshThreads.Services.Interface
{
    public interface IUserServices
    {
        Task<UserDto> GetUserByIdAsync(long id);
        Task UpdateUserAsync(long id, UserDto updatedUser);

        Task DeleteUserAsync(long id);

        public Task<List<UserDto>> GetAllUsersAsync();





    }
}
