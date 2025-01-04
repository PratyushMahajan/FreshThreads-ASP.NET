using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FreshThreads.Contexts;
using FreshThreads.DTO;
using JWTImplementation.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace FreshThreads.Services.Implementation
{
    public class AuthServices : IAuthService
    {

        private readonly ApplicationDBContext applicationDBContext;
        private readonly IConfiguration configuration;

        public AuthServices(ApplicationDBContext applicationDBContext, IConfiguration configuration)
        {
            this.applicationDBContext = applicationDBContext;
            this.configuration = configuration;
        }
        public Users AddUser(UserDto userdto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userdto.Password);
            var user = new Users
            {
                //UsersId = userdto.UsersId,
                Name = userdto.Name,
                Email = userdto.Email,
                Phonenumber = userdto.Phonenumber,
                Address = userdto.Address,
                City = userdto.City,
                Role = userdto.Role,
                CreatedOn = userdto.CreatedOn,
                UpdatedOn = userdto.UpdatedOn,
                Password = hashedPassword // Store the hashed password
            };

            var addedUser = applicationDBContext.Users.Add(user);
            applicationDBContext.SaveChanges();
            return addedUser.Entity;
        }


        public string Login(LoginRequest loginRequest)
        {
            if (!string.IsNullOrEmpty(loginRequest.Email) && !string.IsNullOrEmpty(loginRequest.Password))
            {
                var user = applicationDBContext.Users.SingleOrDefault(u => u.Email == loginRequest.Email);

                if (user != null && BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password)) // Compare hashed passwords
                {
                    var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                new Claim("Id", user.UsersId.ToString()),
                new Claim("UserRole", user.Role.ToString()), // Fix: Convert UserRole to string
                new Claim("Email", user.Email)
            };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        configuration["Jwt:Issuer"],
                        configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                else
                {
                    throw new Exception("Invalid email or password");
                }
            }
            else
            {
                throw new Exception("Email and password are required");
            }
        }

    }
}
