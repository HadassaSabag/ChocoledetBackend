using App.DAL.Entities;
using App.DTO.Models;


namespace App.BL.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetAllUsers();
        public Task<UserDTO> GetUserById(Guid id);
        public Task<Guid> CreateUser(UserDTO user);
        public Task<Guid> UpdateUser(Guid id, UserDTO user);
        public Task<List<UserDTO>> DeleteUser(Guid id);
        public Task<string> LoginUser(string email, string password);


    }
}
