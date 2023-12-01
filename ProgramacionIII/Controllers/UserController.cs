using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Services.Implementations;
using ProgramacionIII.Services.Interfaces;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace ProgramacionIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            try
            {
                string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
                if (role == "Admin") 
                {
                    var rta = _userService.GetAllAdmins();
                    if (rta == null) 
                    {
                        return BadRequest(rta);
                    }
                    return Ok(rta);
                }
                return Forbid("No posee autorizacion");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del seridor" + ex.Message);
            }
            
        }

        //GetAdminByUserName
        [HttpGet("GetAdminByUserName/{username}")] //uno x username
        public IActionResult GetAdminsByUsername(string username)
        {
            try
            {
                string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
                if (role == "Admin")
                {
                    var rta = _userService.GetUserByUsername(username);
                    if (rta == null)
                    {
                        return BadRequest(rta);
                    }
                    return Ok(rta);
                }
                return Forbid("No posee autorizacion");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del seridor" + ex.Message);
            }
            
        }

        //GetAllCustomers
        [HttpGet("GetAllCustomers")] 
        public IActionResult GetAllCustomers()
        {
            try
            {
                string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
                if (role == "Admin")
                {
                    var rta = _userService.GetAllCustomers();
                    if (rta == null)
                    {
                        return BadRequest(rta);
                    }
                    return Ok(rta);
                }
                return Forbid("No posee autorizacion");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del seridor" + ex.Message);
            }
            
        }

        //DeleteUser
        [HttpDelete("DeleteUser/{username}")]
        public IActionResult DeleteUser(string username)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
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
            return Forbid();
                
        }

        //UpdateUser
        [HttpPut("UpdateUser/{username}")]
        public IActionResult UpdateUser([FromRoute] string username, [FromBody] UserPutDto updateUser)
        {
            try
            {
                if (updateUser == null)
                {
                    return BadRequest("Datos de actualización del usuario no proporcionados.");
                }

                var userToUpdate = _userService.GetUserByUsername(username);
                if (userToUpdate == null)
                {
                    return NotFound($"Usuario con username {username} no encontrado.");
                }

                
                userToUpdate.Name = updateUser.Name;
                userToUpdate.LastName = updateUser.LastName;
                userToUpdate.Email = updateUser.Email;
                userToUpdate.UserName = updateUser.UserName;
                userToUpdate.Password = updateUser.Password;

                _userService.UpdateUser(userToUpdate);
                return Ok($"Usuario {username} actualizado con éxito.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el usuario: {ex.Message}");
            }
        }

        //CreateUser
        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserPostDto dto)
        {
                if (dto.Name == "string" || dto.LastName == "string" || dto.Email == "string" || dto.UserName == "string" || dto.Password == "string")
                {
                    return BadRequest("Por favor complete todos los campos para crear el usuario");
                }
                try
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
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
           
            
        }

       
    }
}
