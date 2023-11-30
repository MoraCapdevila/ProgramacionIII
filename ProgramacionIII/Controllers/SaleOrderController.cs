//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Services.Interfaces;

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

        [HttpGet("{SaleOrderId}")] //GetAllOrders
        public IActionResult GetOne(int SaleOrderId) 
        {
            return Ok( _saleOrderService.GetOne(SaleOrderId));
        }

        [HttpGet("{customerId}")] //GetSaleOrderByCustomer
        public IActionResult GetSaleOrderByCustomer(int customerId)
        {
            try
            {
                return Ok(_saleOrderService.GetSaleOrderByCustomer(customerId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //[HttpPost]
        //public IActionResult AddSaleOrder([FromBody] SaleOrderDto dto)
        //{
        //    try
        //    {
        //        _saleOrderService.AddSaleOrder(dto);
        //        return StatusCode(201);

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        [HttpPost]
        public IActionResult AddSaleOrder([FromBody] SaleOrderDto dto)
        {
            var newSaleOrder = new SaleOrder()
            {
                CustomerId = dto.CustomerId,
                TotalPrice = dto.TotalPrice,
                
            };
            newSaleOrder = _saleOrderService.AddSaleOrder(newSaleOrder);
            return Ok($"Orden de venta creada exitosamente con ID: {newSaleOrder.Id}");
        }

        // POST: api/SaleOrder
        [HttpPost("neworden")]
        public async Task<ActionResult<SaleOrder>> CreateSaleOrder(CreateSaleOrderDTO createSaleOrderDTO)
        {
            try
            {
                var newSaleOrder = await _saleOrderService.CreateSaleOrderAsync(createSaleOrderDTO);
                return CreatedAtAction(nameof(GetOne), new { id = newSaleOrder.Id }, newSaleOrder);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutSaleOrder(int id, SaleOrderDto dto)
        {
            var updated = _saleOrderService.UpdateSaleOrder(id, dto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSaleOrder(int id)
        {
            var deleted = _saleOrderService.DeleteSaleOrder(id);

            if (deleted)
            {
                return NoContent(); // La orden de venta fue eliminada con éxito
            }
            else
            {
                return NotFound("La orden de venta no se encontró."); // Mensaje de error si la orden no se encontró
            }
        }
    }
}
