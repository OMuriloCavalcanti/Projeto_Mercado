using APIMercado.Models;
using APIMercado.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMercado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClienteController : ControllerBase
    {
        private readonly ICliente _ICliente;
        public ClienteController(ICliente ICliente)
        {
            _ICliente = ICliente;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get() 
        {
            try
            {
                var clientes = await _ICliente.GetAllAsync();
                return Ok(clientes);
            }
            catch
            {
                return StatusCode(500, "Erro Magnânimo");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O id informa é inválido");

                var clientes = await _ICliente.GetByIdAsync(id);
                if(clientes == null)
                    return NotFound("Cliente não encontrador");  

                return Ok(clientes);
            }
            catch
            {
                return StatusCode(500, "Erro Magnânimo");
            }
        }

        [HttpGet("{id}/pedidos")]
        public async Task<ActionResult<Cliente>> GetPedidosClientes(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O id informa é inválido");

                var clientes = await _ICliente.GetPedidoDoCliente(id);
                if (clientes == null)
                    return NotFound("Cliente não encontrador");

                return Ok(clientes);
            }
            catch
            {
                return StatusCode(500, "Erro Magnânimo");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente(Cliente cliente)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _ICliente.AddAsync(cliente);
                return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
            }
            catch
            {
                return StatusCode(500, "Erro Magnânimo");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O id inforda é inválido");

                var clientes = await _ICliente.GetByIdAsync(id);
                if (clientes == null)
                    return NotFound("Cliente não encontrado");

                return Ok(clientes);
            }
            catch
            {
                return StatusCode(500, "Erro ao excluir");
            }
        }

         /*
          
          Adicionar metódos de service para usuário. Ex: Mudar senha, Email .....   
          
          
          */

    }
}
