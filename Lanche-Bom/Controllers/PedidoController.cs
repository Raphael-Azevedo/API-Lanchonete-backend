using Lanche_Bom.DTO;
using Lanche_Bom.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lanche_Bom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoServices _pedidoServices;

        public PedidoController(IPedidoServices pedidoServices)
        {
            _pedidoServices = pedidoServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemPedido()
        {
            try
            {
                var pedido = await _pedidoServices.GetAllPedido();
                return Ok(pedido);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PedidoDTO pedidoDTO)
        {
            try
            {
                var totalPagar = await _pedidoServices.Create(pedidoDTO);
                return Created("Created", totalPagar);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PedidoDTO pedidoDTO)
        {
            try
            {
                await _pedidoServices.Update(id, pedidoDTO);
                return Accepted("Accepted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _pedidoServices.Delete(id);
                return Ok("The pedido has been deleted!");
            }
            catch (InvalidOperationException)
            {
                return Unauthorized();
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }

        }
    }
}