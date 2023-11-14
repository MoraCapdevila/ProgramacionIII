using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionIII.Data.Entities;
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

        // GET: api/productos/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productService.GetProductById(id); //GetProduct

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/productos
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var createdProduct = _productService.CreateProduct(product); //CreateProduct

            return CreatedAtAction(nameof(Get), new { id = createdProduct.Id }, createdProduct);
        }

        // PUT: api/productos/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            

            _productService.UpdateProduct(product); //UpdateProduct

            return NoContent();
        }

        // DELETE: api/productos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id); //DeleteProduct

            return NoContent();
        }
    }
}
