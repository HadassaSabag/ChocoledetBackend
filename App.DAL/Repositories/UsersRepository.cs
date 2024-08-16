using App.DAL.DataContext;
using App.DAL.Entities;
using App.DAL.Interfaces;


namespace App.DAL.Repositories
{
    public class UsersRepository:IUsersRepository
    {
        public ChocoledetContext dbContext;
        public UsersRepository(ChocoledetContext chocoledetContext)
        {
            dbContext = chocoledetContext;
        }       
        public List<User> GetAllUsers()
        {
            return dbContext.Users.ToList();
        }
        public User GetUserById(Guid id)
        {
            return dbContext.Users.SingleOrDefault(u => u.UserId == id);
        }


        public Guid CreateUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return (Guid)user.UserId;
        }

        public Guid UpdateUser(Guid id, User user)
        {
            User userToUpdate = dbContext.Users.SingleOrDefault(u => u.UserId == id);
            userToUpdate.UserName = user.UserName;
            dbContext.SaveChanges();
            return (Guid)user.UserId;
        }
        public List<User> DeleteUser(Guid id)
        {
            User userToDelete = dbContext.Users.SingleOrDefault(u => u.UserId == id);
            dbContext.Users.Remove(userToDelete);
            dbContext.SaveChanges() ;
            return dbContext.Users.ToList();
        }
    }
}
