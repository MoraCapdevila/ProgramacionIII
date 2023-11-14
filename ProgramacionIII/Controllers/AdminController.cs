using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Services.Implementations;
using ProgramacionIII.Services.Interfaces;

namespace ProgramacionIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;

        public AdminController(IAdminService adminService, IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllAdmins() 
        { 
            return Ok(_adminService.GetAllAdmins());
        }

        [HttpGet("{username}")] //uno x username
        public IActionResult GetAdminsByUsername(string username)
        {
            return Ok(_userService.GetUserByUsername(username));
        }

        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer([FromBody] CustomerPostDto dto)
        {
            var customer = new Customer()
            {
                Email = dto.Email,
                Name = dto.Name,
                LastName = dto.LastName,
                Password = dto.Password,
                UserName = dto.UserName,
                UserType = "Customer"
            };
            int id = _userService.CreateUser(customer);
            return Ok(id);
        }

        [HttpDelete("DeleteCustomer/{username}")]
        public IActionResult DeleteCustomer(string username)
        {
            User existingCustomer = _userService.GetUserByUsername(username);
            if (existingCustomer == null)
            {
                return NotFound($"No se encontró un cliente con el nombre de usuario '{username}'.");
            }
            _userService.DeleteUser(username);
            return Ok("Cliente borrado exitosamente");
        }

        [HttpPost("CreateAdmin")]
        public IActionResult CreateAdmin([FromBody] AdminPostDto dto)
        {
            var admin = new Admin()
            {
                Email = dto.Email,
                Name = dto.Name,
                LastName = dto.LastName,
                Password = dto.Password,
                UserName = dto.UserName,
                UserType = "Admin"
            };
            int id = _userService.CreateUser(admin);
            return Ok(id);
        }

        [HttpDelete("DeleteAdmin/{username}")]
        public IActionResult DeleteAdmin(string username)
        {
            User existingCustomer = _userService.GetUserByUsername(username);
            if (existingCustomer == null)
            {
                return NotFound($"No se encontró un admin con el nombre de usuario '{username}'.");
            }
            _userService.DeleteUser(username);
            return Ok("Admin borrado exitosamente");
        }

        [HttpPut("{username}")]
        public IActionResult UpdateAdmin([FromRoute] string username, [FromBody] UserPutDto updateUser)
        {
            var adminToUpdate = new Admin()
            {
                Name = updateUser.Name,
                LastName = updateUser.LastName,
                Password = updateUser.Password,
                UserName = updateUser.UserName,
                Email = updateUser.Email,
            };
            string updateCustomer = _userService.UpdateUser(adminToUpdate);
            return Ok(updateCustomer);

        }
    }
}
