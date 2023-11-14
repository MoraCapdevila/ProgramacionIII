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



        [HttpPut("{username}")]
        public IActionResult UpdateCustomer([FromRoute] string username, [FromBody] UserPutDto updateUser)
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
