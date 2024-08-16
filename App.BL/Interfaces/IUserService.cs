using App.DTO.Models;


namespace App.BL.Interfaces
{
    public interface IUserService
    {
        public List<UserDTO> GetAllUsers();
        public UserDTO GetUserById(Guid id);
        public Guid CreateUser(UserDTO user);
        public Guid UpdateUser(Guid id, UserDTO user);
        public List<UserDTO> DeleteUser(Guid id);

    }
}
