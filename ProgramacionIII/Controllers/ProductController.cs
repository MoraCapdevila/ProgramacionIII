using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Services.Implementations;
using ProgramacionIII.Services.Interfaces;
using System.Security.Claims;
using System.Xml.Linq;

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



        [HttpPut("{id}")]
        public IActionResult PutProduct([FromRoute] int id, [FromBody] ProductPutDto productDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                try
                {
                    if (productDto == null)
                    {
                        return BadRequest("Datos de actualización del producto no proporcionados.");
                    }
                    var productUpdate = _productService.GetProductById(id);
                    if (productUpdate == null)
                    {
                        return NotFound($"Producto con id {id} no encontrado.");
                    }
                    productUpdate.Name = productDto.Name;
                    productUpdate.Description = productDto.Description;
                    productUpdate.Price = productDto.Price;

                    _productService.UpdateProduct(productUpdate);
                    return Ok($"Producto {id} actualizado con éxito.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error al actualizar el producto: {ex.Message}");
                }
            }
            return Forbid();   
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
