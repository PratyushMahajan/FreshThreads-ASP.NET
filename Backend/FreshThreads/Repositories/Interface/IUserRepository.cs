namespace FreshThreads.Repositories.Interface
{
    public interface IUserRepository 
    {


        public List<Users> GetAllUsers();
        public Users GetUserById(long id);
        public Users CreateUser(Users user);

        public Users UpdateUser(Users user);

        public bool DeleteUser(long id);

    }
}
