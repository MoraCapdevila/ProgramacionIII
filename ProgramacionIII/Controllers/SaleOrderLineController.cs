using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Services.Interfaces;
using System.Security.Claims;

namespace ProgramacionIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleOrderLineController : ControllerBase
    {
        private readonly ISaleOrderLineService _saleOrderLineService;

        public SaleOrderLineController(ISaleOrderLineService saleOrderLineService)
        {
            _saleOrderLineService = saleOrderLineService;
        }

        [HttpGet] //all
        public IActionResult GetAllSaleOrderLines()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                try
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
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();   
        }

        [HttpGet("{saleOrderLineId}")] //ById
        public IActionResult GetSaleOrderLine(int saleOrderLineId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                try
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
                        return NotFound("SaleOrderLine no encontrada"); 
                    }
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
                
        }

        [HttpDelete("{saleOrderLineId}")]
        public IActionResult DeleteSaleOrderLineById(int saleOrderLineId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                try
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
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
                
        }

        [HttpPost]
        public IActionResult CreateSaleOrderLine([FromBody] SaleOrderLineDTO dto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                try
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
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
                

        }



    }
}
