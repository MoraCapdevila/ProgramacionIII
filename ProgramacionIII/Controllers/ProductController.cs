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
            return Ok(_productService.GetProductById(id)); //GetProductById
        }
        
        //GET: api/products
        [HttpGet]
        public IActionResult GetAllProducts() 
        { 
            return Ok(_productService.GetProducts()); //GetProducts
        }

        // POST: api/products
        [HttpPost]
        public IActionResult PostProduct([FromBody] ProductPostDto productdto)
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
            await _productService.DeleteProduct(id); //DeleteProduct

            return NoContent();
        }
    }
}
