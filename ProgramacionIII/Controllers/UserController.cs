using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Services.Implementations;
using ProgramacionIII.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace ProgramacionIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        //GetAllAdmins
        [HttpGet("GetAllAdmins")]
        public IActionResult GetAllAdmins()
        {
            return Ok(_userService.GetAllAdmins());
        }
        //GetAdminByUserName
        [HttpGet("GetAdminByUserName/{username}")] //uno x username
        public IActionResult GetAdminsByUsername(string username)
        {
            return Ok(_userService.GetUserByUsername(username));
        }
        //GetAllCustomers
        [HttpGet("GetAllCustomers")] 
        public IActionResult GetAllCustomers()
        {
            return Ok(_userService.GetAllCustomers());
        }
        //DeleteUser
        [HttpDelete("DeleteUser/{username}")]
        public IActionResult DeleteUser(string username)
        {
            try
            {
                User existingUser = _userService.GetUserByUsername(username);
                if (existingUser == null)
                {
                    return NotFound($"No se encontró un cliente con el nombre de usuario {username}.");
                }
                _userService.DeleteUser(username);
                return Ok("Cliente borrado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error al eliminar el usuario: {ex.Message}");
            }
        }
        [HttpPut("UpdateUser/{username}")]
        public IActionResult UpdateUser([FromRoute] string username, [FromBody] UserPutDto updateUser)
        {
            var userToUpdate = new Customer()
            {
                Name = updateUser.Name,
                LastName = updateUser.LastName,
                Password = updateUser.Password,
                UserName = updateUser.UserName,
                Email = updateUser.Email,
            };
            string updateCustomer = _userService.UpdateUser(userToUpdate);
            return Ok(updateCustomer);
        }
        //UpdateUser
        //[HttpPut("UpdateUser/{username}")]
        //public IActionResult UpdateUser([FromRoute] string username, [FromBody] UserPutDto updateUser)
        //{
        //    var userToUpdate = new Customer()
        //    {
        //        Name = updateUser.Name,
        //        LastName = updateUser.LastName,
        //        Password = updateUser.Password,
        //        UserName = updateUser.UserName,
        //        Email = updateUser.Email,
        //    };
        //    string updateCustomer = _userService.UpdateUser(userToUpdate);
        //    return Ok(updateCustomer);
        //}
        //CreateUser
        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserPostDto dto)
        {
            var customer = new Customer()
            {
                Email = dto.Email,
                Name = dto.Name,
                LastName = dto.LastName,
                Password = dto.Password,
                UserName = dto.UserName,
                UserType = dto.UserType,
            };
            int id = _userService.CreateUser(customer);
            return Ok(id);
        }

       
    }
}
