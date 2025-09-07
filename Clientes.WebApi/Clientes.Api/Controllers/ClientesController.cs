using Clientes.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            var clientes = await _context.Clientes
                .Include(c => c.Telefones)
                .ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(Guid id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Telefones)
                .FirstOrDefaultAsync(c => c.CodigoCliente == id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(Cliente cliente)
        {
            cliente.UsuarioInsercao = "sistema"; // pode vir do contexto de login

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = cliente.CodigoCliente }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Cliente cliente)
        {
            if (id != cliente.CodigoCliente)
                return BadRequest();

            var existente = await _context.Clientes.FindAsync(id);
            if (existente == null)
                return NotFound();

            // Atualiza campos
            existente.RazaoSocial = cliente.RazaoSocial;
            existente.NomeFantasia = cliente.NomeFantasia;
            existente.TipoPessoa = cliente.TipoPessoa;
            existente.Documento = cliente.Documento;
            existente.Endereco = cliente.Endereco;
            existente.Complemento = cliente.Complemento;
            existente.Bairro = cliente.Bairro;
            existente.Cidade = cliente.Cidade;
            existente.CEP = cliente.CEP;
            existente.UF = cliente.UF;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
