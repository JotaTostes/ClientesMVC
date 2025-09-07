using Clientes.Application.Interfaces;
using Clientes.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(Guid id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);

            return cliente is null
                ? NotFound()
                : Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(Cliente cliente)
        {
            await _clienteService.AddClienteAsync(cliente);

            return CreatedAtAction(nameof(GetById), new { id = cliente.CodigoCliente }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Cliente cliente)
        {
            var res = await _clienteService.UpdateClienteAsync(id, cliente);

            return res ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await _clienteService.DeleteClienteAsync(id);

            return res ? Ok() : NotFound();
        }
    }
}
