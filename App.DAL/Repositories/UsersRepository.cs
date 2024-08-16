using App.DAL.DataContext;
using App.DAL.Entities;
using App.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace App.DAL.Repositories
{
    public class UsersRepository:IUsersRepository
    {
        public ChocoledetContext dbContext;
        public UsersRepository(ChocoledetContext chocoledetContext)
        {
            dbContext = chocoledetContext;
        }       
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await dbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בשליפת נתונים");
            }
        }
        public async Task<User> GetUserById(Guid id)
        {
            try
            {
            return await dbContext.Users.SingleOrDefaultAsync(u => u.UserId == id);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<Guid> CreateUser(User user)
        {
            try
            {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return (Guid)user.UserId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<Guid> UpdateUser(Guid id, User user)
        {
            try
            {
            User userToUpdate = await dbContext.Users.SingleOrDefaultAsync(u => u.UserId == id);
            userToUpdate.UserName = user.UserName;
            await dbContext.SaveChangesAsync();
            return (Guid)user.UserId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public async Task<List<User>> DeleteUser(Guid id)
        {
            try
            {
            User userToDelete = await dbContext.Users.SingleOrDefaultAsync(u => u.UserId == id);
            dbContext.Users.Remove(userToDelete);
            await dbContext.SaveChangesAsync() ;
            return await dbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
