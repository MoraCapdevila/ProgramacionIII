//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Services.Interfaces;
using ProgramacionIII.Services.Implementations;

namespace ProgramacionIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrderController : ControllerBase
    {
        private readonly ISaleOrderService _saleOrderService;

        public SaleOrderController (ISaleOrderService saleOrderService)
        {
            _saleOrderService = saleOrderService;
        }



        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<SaleOrder>>> GetAllSaleOrders()
        {
            try
            {
                var saleOrders = await _saleOrderService.GetAllSaleOrdersAsync();
                return Ok(saleOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SaleOrder> GetSaleOrderById(int id)
        {
            try
            {
                var saleOrder = _saleOrderService.GetSaleOrderById(id);

                if (saleOrder == null)
                {
                    return NotFound($"SaleOrder con ID {id} no encontrada");
                }

                return Ok(saleOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("customer/{customerId}")]
        public ActionResult<IEnumerable<SaleOrder>> GetSaleOrdersByCustomerId(int customerId)
        {
            try
            {
                var saleOrders = _saleOrderService.GetSaleOrdersByCustomerId(customerId);

                if (saleOrders == null || !saleOrders.Any())
                {
                    return NotFound($"No se encontraron ordens del cliente ID {customerId}");
                }

                return Ok(saleOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost] //crea una orden
        public IActionResult AddSaleOrder([FromBody] SaleOrderDto dto)
        {
            var newSaleOrder = new SaleOrder()
            {
                CustomerId = dto.CustomerId,
                ProductId = dto.ProductId,
                ProductQuantity = dto.ProductQuantity,

            };
            newSaleOrder = _saleOrderService.AddSaleOrder(newSaleOrder);
            return Ok($"Orden de venta creada exitosamente con ID: {newSaleOrder.Id}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSaleOrder(int id)
        {
            try
            {
                var deleted = _saleOrderService.DeleteSaleOrder(id);

                if (!deleted)
                {
                    return NotFound($"SaleOrder coon ID {id} no encontrado");
                }

                return Ok($"SaleOrder con ID {id} borrado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSaleOrder(int id, [FromBody] SaleOrderDto dto)
        {
            try
            {
                var saleOrderToUpdate = new SaleOrder()
                {
                    Id = id,
                    CustomerId = dto.CustomerId,
                    ProductId = dto.ProductId,
                    ProductQuantity = dto.ProductQuantity,

                };

                var updatedSaleOrder = _saleOrderService.UpdateSaleOrder(saleOrderToUpdate);

                if (updatedSaleOrder == null)
                {
                    return NotFound($"SaleOrder con ID {id} no encontrado");
                }

                return Ok($"SaleOrder with ID {id} actualizado con exito");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }



        }
    }
}
