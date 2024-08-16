using App.DAL.Entities;
using App.DTO.Models;


namespace App.BL.Mappers
{
    internal static class UserMapper
    {
        internal static User Map(UserDTO user)
        {
            return new User
            {
                UserId=user.UserId,
                UserName=user.UserName,
                Email=user.Email,
                Password=user.Password,
                CreatedAt = user.CreatedAt,
            };
        }
        internal static UserDTO Map(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
            };
        }
    }
}
