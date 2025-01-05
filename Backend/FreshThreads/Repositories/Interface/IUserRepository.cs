using FreshThreads.DTO;

namespace FreshThreads.Repositories.Interface
{
    public interface IUserRepository 
    {


        Task<UserDto> GetUserByIdAsync(long id);
        Task UpdateUserAsync(UserDto user);

        Task DeleteUserByIdAsync(long id);
        public Task<List<UserDto>> GetAllUsersAsync();
    }
}
