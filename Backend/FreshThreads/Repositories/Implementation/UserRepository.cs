using FreshThreads.Contexts;
using FreshThreads.Repositories.Interface;

namespace FreshThreads.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext Dbcontext;
        public UserRepository(ApplicationDBContext context)
        {
            Dbcontext = context;
        }
        public Users CreateUser(Users user)
        {
            var use = Dbcontext.Users.Add(user);
            Dbcontext.SaveChanges();
            return use.Entity;
        }

        public bool DeleteUser(long id)
        {
            try
            {
                var use = Dbcontext.Users.SingleOrDefault(s => s.UsersId == id);
                if (use == null)
                    throw new Exception("user not found");
                else
                {
                    Dbcontext.Users.Remove(use);
                    Dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Users> GetAllUsers()
        {
            var use = Dbcontext.Users.ToList();
            return use;

        }

        public Users GetUserById(long id)
        {
            var use = Dbcontext.Users.SingleOrDefault(s => s.UsersId == id);
            return use;
        }

        public Users UpdateUser(Users user)
        {
            var updated = Dbcontext.Users.Update(user);
            Dbcontext.SaveChanges();
            return updated.Entity;
        }
    }
}
