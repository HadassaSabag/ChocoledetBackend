using App.Api.Mappers;
using App.Api.Models;
using App.BL.Interfaces;
using App.DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService usersService)
        {
            _userService= usersService;
        }
        [HttpGet]
        public List<UserDTO> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public UserDTO GetUserById(Guid id)
        {
            return _userService.GetUserById(id);
        }
        [HttpPost]
        public Guid CreateUser(UserRequest user)
        {
            return _userService.CreateUser(UserMapper.Map(user));
        }
        [HttpPut]
        public Guid UpdateUser(Guid id, UserRequest user)
        {
            return _userService.UpdateUser(id, UserMapper.Map(user));
        }
        [HttpDelete]
        public List<UserDTO> DeleteUser(Guid id)
        {
            return _userService.DeleteUser(id);
        }

    }
}
