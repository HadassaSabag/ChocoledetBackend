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
        public List<UserDTO> GetAllUsers()
        {
            List<User> usersList = users.GetAllUsers();
            return usersList.Select(u=>UserMapper.Map(u)).ToList();
        }
        public UserDTO GetUserById(Guid id)
        {
            return UserMapper.Map(users.GetUserById(id));
        }

        public Guid CreateUser(UserDTO user)
        {
            return users.CreateUser(UserMapper.Map(user));
        }
        public Guid UpdateUser(Guid id, UserDTO user)
        {
            return users.UpdateUser(id, UserMapper.Map(user));
        }
        public List<UserDTO> DeleteUser(Guid id)
        {
            List <User> newUserList = users.DeleteUser(id);
            
            return newUserList.Select(u => UserMapper.Map(u)).ToList();
        }
    }
}
