using App.Api.Mappers;
using App.Api.Models;
using App.BL.Interfaces;
using App.DAL.Entities;
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
        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
            return await _userService.GetAllUsers();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> GetUserById(Guid id)
        {
            try
            {
                return await _userService.GetUserById(id);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        public async Task<Guid> CreateUser([FromBody] UserRequest user)
        {
            try
            {           
                return await _userService.CreateUser(UserMapper.Map(user));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPut]
        public async Task<Guid> UpdateUser( Guid id,[FromBody] UserRequest user)
        {
            try
            {
            return await _userService.UpdateUser(id, UserMapper.Map(user));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpDelete("{id}")]
        public async Task<List<UserDTO>> DeleteUser(Guid id)
        {
            try
            {
            return await _userService.DeleteUser(id);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
