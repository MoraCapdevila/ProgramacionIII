using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Services.Interfaces;



namespace ProgramacionIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrderLineController : ControllerBase
    {
        private readonly ISaleOrderLineService _saleOrderLineService;

        public SaleOrderLineController(ISaleOrderLineService saleOrderLineService)
        {
            _saleOrderLineService = saleOrderLineService;
        }

        [HttpGet]
        public IActionResult GetAllSaleOrderLines()
        {
            var allSaleOrderLines = _saleOrderLineService.GetAllSaleOrderLines();

            if (allSaleOrderLines != null && allSaleOrderLines.Any())
            {
                return Ok(allSaleOrderLines);
            }
            else
            {
                return NotFound("No SaleOrderLines found");
            }
        }

        [HttpGet("{saleOrderLineId}")]
        public IActionResult GetSaleOrderLine(int saleOrderLineId)
        {
            var saleOrderLine = _saleOrderLineService.GetSaleOrderLine(saleOrderLineId);

            if (saleOrderLine != null)
            {
                var productName = saleOrderLine.Product?.Name;
                var orderTotalPrice = saleOrderLine.Product?.Price;
                var productQuantity = saleOrderLine.ProductQuantity;

               
                    var response = new
                    {
                        IdSaleOrderLine = saleOrderLine.SaleOrderLineId,
                        ProductName = productName,
                        ProductQuantity = productQuantity,
                        Price = orderTotalPrice,
                        TotalPrice = orderTotalPrice * productQuantity,
                    };

                    return Ok(response);
                
            }
            else
            {
                return NotFound("SaleOrderLine no encontrada"); //traducir
            }
        }

        [HttpDelete("{saleOrderLineId}")]
        public IActionResult DeleteSaleOrderLineById(int saleOrderLineId)
        {
            var result = _saleOrderLineService.DeleteSaleOrderLineById(saleOrderLineId);

            if (result)
            {
                return Ok("SaleOrderLine borrada con exito");
            }
            else
            {
                return NotFound("Error al borrar SaleOrderLine");
            }
        }

        [HttpPost]
        public IActionResult CreateSaleOrderLine([FromBody] SaleOrderLineDTO dto)
        {
            int saleOrderLineId = _saleOrderLineService.CreateSaleOrderLine(dto);

            if (saleOrderLineId != 0)
            {
                return Ok($"SaleOrderLine creada exitosamente con ID: {saleOrderLineId}");
            }
            else
            {
                return BadRequest("Error al crear SaleOrderLine");
            }

        }



    }
}
