using Lanche_Bom.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lanche_Bom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoServices _itemPedidoServices;

        public ItemPedidoController(IItemPedidoServices itemPedidoServices)
        {
            _itemPedidoServices = itemPedidoServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemPedido()
        {
            try
            {
                var itemPedido = await _itemPedidoServices.GetAllItemPedido();
                return Ok(itemPedido);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }

        [HttpGet("GetLanches")]
        public async Task<IActionResult> GetItemPedidoCategoriaLanches()
        {
            try
            {
                var itemPedidoLanches = await _itemPedidoServices.GetItemPedidoCategoriaLanches();
                return Ok(itemPedidoLanches);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        
        [HttpGet("GetAdicionais")]
        public async Task<IActionResult> GetItemPedidoCategoriaAdicionais()
        {
            try
            {
                var itemPedidoAdicionais = await _itemPedidoServices.GetItemPedidoCategoriaAdicionais();
                return Ok(itemPedidoAdicionais);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
    }
}