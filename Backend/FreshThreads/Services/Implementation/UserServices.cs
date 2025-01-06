using FreshThreads.DTO;
using FreshThreads.Repositories.Interface;
using FreshThreads.Services.Interface;

namespace FreshThreads.Services.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task DeleteUserAsync(long id)
        {
            return _userRepository.DeleteUserByIdAsync(id);
        }

        public Task<List<UserDto>> GetAllUsersAsync()
        {
            return _userRepository.GetAllUsersAsync();
            }
           // throw new NotImplementedException();
        

        public async Task<UserDto> GetUserByIdAsync(long id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task UpdateUserAsync(long id, UserDto updatedUser)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }
            
            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Phonenumber = updatedUser.Phonenumber;
            existingUser.Address = updatedUser.Address;
            existingUser.Password = updatedUser.Password;
            existingUser.City = updatedUser.City;
            existingUser.Role = updatedUser.Role;
            existingUser.UpdatedOn = DateTime.UtcNow;

            await _userRepository.UpdateUserAsync(existingUser);
        }
    }
}
