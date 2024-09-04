using App.BL.Interfaces;
using App.BL.Mappers;
using App.DAL.Entities;
using App.DAL.Interfaces;
using App.DTO.Models;


namespace App.BL.Services
{
    public class UserService: IUserService
    {
        public IUsersRepository users;
        public UserService(IUsersRepository usersRepository)
        {
            users = usersRepository;
        }
        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
            List<User> usersList =await users.GetAllUsers();
            return  usersList.Select(u=>UserMapper.Map(u)).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public async Task<UserDTO> GetUserById(Guid id)
        {
            try
            {
            var user = await users.GetUserById(id); 
            return UserMapper.Map(user); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<Guid> CreateUser(UserDTO user)
        {
            try
            {
            return await users.CreateUser(UserMapper.Map(user));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<Guid> UpdateUser(Guid id, UserDTO user)
        {
            try
            {
            return await users.UpdateUser(id, UserMapper.Map(user));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<UserDTO>> DeleteUser(Guid id)
        {
            try
            {
                var newUserList = await users.DeleteUser(id);
                var userDTOList = newUserList.Select(u => UserMapper.Map(u)).ToList();
                return userDTOList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public async Task<string> LoginUser(string email, string password)
        {
            try
            {
                return await users.LoginUser(email, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
