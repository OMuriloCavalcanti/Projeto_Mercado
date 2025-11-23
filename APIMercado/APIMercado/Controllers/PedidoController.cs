using APIMercado.Models;
using APIMercado.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMercado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedido _IPedido;
        public PedidoController(IPedido IPedido)
        {
            _IPedido = IPedido; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetAllPedido()
        {
            try
            {
                var pedidos = await _IPedido.GetAllAsync();
                return Ok(pedidos);
            }
            catch
            {
                return StatusCode(500, "Erro Magnânimo");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedidoById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id informado é inválido");

                var pedido = await _IPedido.GetByIdAsync(id);
                if (pedido == null)
                    return NotFound("Pedido não existe");

                return Ok(pedido);  
            }
            catch
            {
                return StatusCode(500, "Erro Magnânimo");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> CreatePedido(Pedido pedido)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _IPedido.AddAsync(pedido);
                return CreatedAtAction(nameof(GetPedidoById), new { id = pedido.Id }, pedido);
            }
            catch
            {
                return StatusCode(500, "Erro ao realizar pedido");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Pedido>> EditPedido(int id, Pedido pedido)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id informado é inválido");
                
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingPedido = await _IPedido.GetByIdAsync(id);
                if (existingPedido == null)
                    return NotFound("Pedido não encontrado");

                existingPedido.ProdutoId = pedido.ProdutoId;
                existingPedido.ClienteId = pedido.ClienteId;

                await _IPedido.UpdateAsync(existingPedido);
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Erro ao editar pedido");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> DeletePedido(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id informado é inválido");

                var pedido = await _IPedido.GetByIdAsync(id);
                if (pedido == null)
                    return NotFound("Pedido não encontrado");

                await _IPedido.DeleteAsync(pedido);

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Não foi possível apagar esse pedido");
            }
        }
    }
}
