using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Services.Implementations;
using ProgramacionIII.Services.Interfaces;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace ProgramacionIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;

        public CustomerController(ICustomerService customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService; 
        }

        [HttpGet] //all
        public IActionResult GetAllCustomers() 
        {
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpGet("{username}")] //uno x username
        public IActionResult GetCustomerByUsername(string username)
        {
            return Ok(_userService.GetUserByUsername(username));
        }

        [HttpPost]
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

        [HttpPut("{username}")]
        public IActionResult UpdateCustomer([FromRoute]string username,[FromBody]CustomerPutDto updateUser)
        {
            User existingCustomer = _userService.GetUserByUsername(username);
            if (existingCustomer == null)
            {
                return NotFound($"No se encontró un cliente con el nombre de usuario '{username}'.");
            }
            existingCustomer.LastName = updateUser.LastName ?? existingCustomer.LastName;
            existingCustomer.Name = updateUser.Name ?? existingCustomer.Name;
            existingCustomer.Password = updateUser.Password ?? existingCustomer.Password;
            existingCustomer.UserName = updateUser.UserName ?? existingCustomer.UserName;
            //agregar email

            _userService.UpdateUser(username,updateUser);
            return Ok();

           
        }

        [HttpDelete("{username}")]
        public IActionResult DeleteCustomer(string username)
        {
            User existingCustomer = _userService.GetUserByUsername(username);
            if (existingCustomer == null)
            {
                return NotFound($"No se encontró un cliente con el nombre de usuario '{username}'.");
            }
            _userService.DeleteUser(username);
            return NoContent();
        }

    }

    

}
