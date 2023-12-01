using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Services.Implementations;
using ProgramacionIII.Services.Interfaces;
using System.Security.Claims;

namespace ProgramacionIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                var product = _productService.GetProductById(id);

                if (product == null)
                {
                    return NotFound($"El producto con el ID: {id} no fue encontrado");
                }

                return Ok(product);
            }
            return Forbid();
           
        }
        
        //GET: api/products
        [HttpGet] //all
        public IActionResult GetAllProducts() 
        { 
            return Ok(_productService.GetProducts()); //GetProducts
        }

        // POST: api/products
        [HttpPost]
        public IActionResult PostProduct([FromBody] ProductPostDto productdto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                if (productdto.Name == null || productdto.Price <= 0)
                {
                    return BadRequest("No se pudo crear el producto, asegurese de completar correctamente todos los campos");
                }
                try
                {
                    var product = new Product()
                    {
                        Name = productdto.Name,
                        Description = productdto.Description,
                        Price = productdto.Price,
                    };
                    int id = _productService.CreateProduct(product); //CreateProduct
                    return Ok(id);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();   
            
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromBody] ProductPutDto dto)
        {
            var product = new Product()
            {
                Name= dto.Name,
                Description= dto.Description,
                Price = dto.Price,
            };
            
            _productService.UpdateProduct(product); //UpdateProduct

            return Ok("Producto actualizado con exito");
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                try
                {
                    await _productService.DeleteProduct(id); //DeleteProduct
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();   

            
        }
    }
}
