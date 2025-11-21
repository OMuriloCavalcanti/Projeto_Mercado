using APIMercado.Models;
using APIMercado.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMercado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProduto _IProduto;
        public ProdutoController(IProduto IProduto)
        {
            _IProduto = IProduto;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAll()
        {
            try
            {
                var produtos = await _IProduto.GetAllAsync();
                return Ok(produtos);
            }
            catch
            {
                return StatusCode(500, "Erro Magnânimo");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O id informado é invalido");

                var produto = await _IProduto.GetByIdAsync(id);
                if (produto == null)
                    return NotFound("Produto não encontrado");

                return Ok(produto);
            }
            catch
            {
                return StatusCode(500, "Erro Magnânimo");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> CreateProduto(Produto produto)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _IProduto.AddAsync(produto);
                return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
            }
            catch{
                return StatusCode(500, "Erro Magnânimo");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> DeleteProduto(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O Id informado é inválido");

                var produto = await _IProduto.GetByIdAsync(id);
                if (produto == null)
                    return NotFound("Produto não encontrado");

                await _IProduto.DeleteAsync(produto);
                return NoContent(); 
            }
            catch
            {
                return StatusCode(500, "Erro ao excluir");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Update(int id, Produto produto)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O id informado é inválido");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingProduto = await _IProduto.GetByIdAsync(id);
                if (existingProduto == null)
                    return NotFound("Produto não encontrado");

                existingProduto.Name = produto.Name;
                existingProduto.Value = produto.Value;  

                await _IProduto.UpdateAsync(existingProduto);
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Erro ao atualizar");
            }
        }
    }
}
