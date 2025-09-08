using Clientes.Application.DTOs.Cliente;
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
        [ProducesResponseType(typeof(List<Cliente>), 200)]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), 200)]
        public async Task<ActionResult<Cliente>> GetById(Guid id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);

            return cliente is null
                ? NotFound()
                : Ok(cliente);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cliente), 201)]
        [ProducesResponseType(typeof(List<string>), 400)]
        public async Task<ActionResult<Cliente>> Create([FromBody] CreateClienteDto clienteDto)
        {
            var response = await _clienteService.AddClienteAsync(clienteDto);

            return CreatedAtAction(nameof(GetById), new { id = response.CodigoCliente }, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(List<string>), 400)]
        [ProducesResponseType(typeof(List<string>), 404)]
        public async Task<IActionResult> Update(Guid id, Cliente cliente)
        {
            var (success, erros) = await _clienteService.UpdateClienteAsync(id, cliente);

            return success ? NoContent() : BadRequest(new { Mensagem = "Erro ao atualizar informações do cliente.", Erros = erros });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(List<string>), 404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var (success, erros) = await _clienteService.DeleteClienteAsync(id);

            return success ? NoContent() : NotFound(new { Mensagem = "Erro ao deletar cliente.", Erros = erros });
        }
    }
}
