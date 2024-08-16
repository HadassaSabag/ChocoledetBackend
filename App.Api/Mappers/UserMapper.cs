using App.Api.Models;
using App.DTO.Models;

namespace App.Api.Mappers
{
    internal static class UserMapper
    {
        internal static UserDTO Map(UserRequest userRequest)
        {
            return new UserDTO
            {
                UserId = Guid.NewGuid(),
                UserName = userRequest.UserName,
                Email = userRequest.Email,
                Password = userRequest.Password,
                CreatedAt = DateTime.Now,
            };
        }
    }
}
