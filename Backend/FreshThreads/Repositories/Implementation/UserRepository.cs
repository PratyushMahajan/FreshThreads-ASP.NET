using FreshThreads.Contexts;
using FreshThreads.DTO;
using FreshThreads.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using FreshThreads.Models;

namespace FreshThreads.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext Dbcontext;
        public UserRepository(ApplicationDBContext context)
        {
            Dbcontext = context;
        }

        public async Task DeleteUserByIdAsync(long id)
        {
            // Retrieve the user by ID
            var user = await Dbcontext.Users.FindAsync(id);
            if (user == null) {
                throw new Exception("User not found");
            }

            // Remove the user from the database
            Dbcontext.Users.Remove(user);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return await Dbcontext.Users
                .Select(user => new UserDto
                {
                    UsersId=user.UsersId,
                    Name = user.Name,
                    Email = user.Email,
                    Phonenumber = user.Phonenumber,
                    Address = user.Address,
                    //Password = user.Password,
                    City = user.City,
                    Role = user.Role,
                    CreatedOn = user.CreatedOn,
                    UpdatedOn = user.UpdatedOn
                })
                .ToListAsync();
        }

        public async Task<UserDto> GetUserByIdAsync(long id)
        {
            var user = await Dbcontext.Users.FindAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Name = user.Name,
                Email = user.Email,
                Phonenumber = user.Phonenumber,
                Address = user.Address,
                //Password = user.Password,
                City = user.City,
                Role = user.Role,
                CreatedOn = user.CreatedOn,
                UpdatedOn = user.UpdatedOn
            };
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = await Dbcontext.Users.FindAsync(userDto.UsersId); // Fetch the entity by ID
            if (user == null) throw new KeyNotFoundException("User not found");

            // Update properties
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Phonenumber = userDto.Phonenumber;
            user.Address = userDto.Address;
            user.Password = userDto.Password;
            user.City = userDto.City;
            user.Role = userDto.Role;
            user.UpdatedOn = DateTime.UtcNow; // Update the timestamp

            // Save changes
            await Dbcontext.SaveChangesAsync();

        }

    }
}
