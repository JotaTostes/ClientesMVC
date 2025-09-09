using Clientes.Application.DTOs.TipoTelefone;
using Clientes.Application.Interfaces;
using Clientes.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneService _telefoneService;

        public TelefoneController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }

        /// <summary>
        /// Busca todos os telefones de um cliente específico.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<Telefone>), 200)]
        public async Task<IActionResult> Get(Guid clienteId)
        {
            var telefones = await _telefoneService.GetTelefonesByClienteAsync(clienteId);
            return Ok(telefones);
        }

        /// <summary>
        /// Adiciona um novo telefone para um cliente.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Telefone), 201)]
        [ProducesResponseType(typeof(List<string>), 400)]
        public async Task<IActionResult> Create(Guid clienteId, [FromBody] Telefone telefone)
        {
            var (success, erros) = await _telefoneService.AddTelefoneAsync(telefone);

            return success ? CreatedAtAction(nameof(Get), new { clienteId = telefone.CodigoCliente }, telefone) : BadRequest(new { Errors = erros });
        }

        [HttpPut("{numeroTelefone}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(List<string>), 400)]
        [ProducesResponseType(typeof(List<string>), 404)]
        public async Task<IActionResult> Update(Guid clienteId, string numeroTelefone, [FromBody] Telefone telefone)
        {

            var (success, erros) = await _telefoneService.UpdateTelefoneAsync(clienteId, telefone);

            return success ? NoContent() : BadRequest(new { Mensagem = "Erro ao atualizar informações de telefone.", Erros = erros });
        }

        /// <summary>
        /// Remove um telefone de um cliente.
        /// </summary>
        [HttpDelete("{numeroTelefone}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(List<string>), 404)]
        public async Task<IActionResult> Delete(string numeroTelefone)
        {
            var (success, erros) = await _telefoneService.RemoverTelefoneAsync(numeroTelefone);

            return success ? NoContent() : NotFound(new { Mensagem = "Erro ao deletar telefone.", Erros = erros });
        }

        [HttpGet("tipos-telefone")]
        [ProducesResponseType(typeof(List<ResponseTipoTelefoneDto>), 200)]
        public async Task<IActionResult> GetTiposTelefones()
        {
            var telefones = await _telefoneService.GetTiposTelefone();
            return Ok(telefones);
        }
    }
}
