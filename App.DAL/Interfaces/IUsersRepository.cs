using App.DAL.Entities;


namespace App.DAL.Interfaces
{
    public interface IUsersRepository
    {
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserById(Guid id);
        public Task<Guid> CreateUser(User user);
        public Task<Guid> UpdateUser(Guid id, User user);
        public Task<List<User>> DeleteUser(Guid id);
        public Task<string> LoginUser(string email, string password);


    }
}
