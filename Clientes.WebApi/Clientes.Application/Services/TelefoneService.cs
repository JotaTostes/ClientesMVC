using Clientes.Application.DTOs.Telefone;
using Clientes.Application.DTOs.TipoTelefone;
using Clientes.Application.Extensions;
using Clientes.Application.Interfaces;
using Clientes.Domain.Entities;
using Clientes.Domain.Interfaces;

namespace Clientes.Application.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly ITipoTelefoneRepository _tipoTelefoneRepository;

        public TelefoneService(ITelefoneRepository telefoneRepository, ITipoTelefoneRepository tipoTelefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
            _tipoTelefoneRepository = tipoTelefoneRepository;
        }

        public async Task<List<Telefone>> GetTelefonesByClienteAsync(Guid codigoCliente)
        {
            return await _telefoneRepository.GetByClienteAsync(codigoCliente);
        }

        public async Task<(bool Success, List<string>Errors)> AddTelefoneAsync(CreateTelefoneDto telefoneDto)
        {
            if (telefoneDto == null || string.IsNullOrWhiteSpace(telefoneDto.NumeroTelefone))
                return (false, new List<string> { "Telefone inválido." });


            var telefoneExistente = await _telefoneRepository.GetAsync(telefoneDto.CodigoCliente, telefoneDto.NumeroTelefone);

            if (telefoneExistente != null)
                return (false, new List<string> { "Telefone já cadastrado para este cliente." });

            await _telefoneRepository.AddAsync(telefoneDto.ToEntity());
            return (true, new List<string>());
        }

        public async Task<(bool Success,List<string>Errors)> UpdateTelefoneAsync(Guid codigoCliente, Telefone telefone)
        {
            var telefoneParaAtualizar = await _telefoneRepository.GetAsync(codigoCliente, telefone.NumeroTelefone);

            if (telefoneParaAtualizar == null)
                return (false, new List<string> { "Telefone não encontrado." });

            telefoneParaAtualizar.CodigoTipoTelefone = telefone.CodigoTipoTelefone;
            telefoneParaAtualizar.Operadora = telefone.Operadora;
            telefoneParaAtualizar.NumeroTelefone = telefone.NumeroTelefone;

            await _telefoneRepository.UpdateAsync(telefoneParaAtualizar);

            return (true,new List<string>());
        }

        public async Task<(bool Success, List<string>Errors)> RemoverTelefoneAsync(string numeroTelefone)
        {
            var telefoneExistente = await _telefoneRepository.GetByNumeroAsync(numeroTelefone);
            if (telefoneExistente == null)
                return (false, new List<string> { "Telefone não encontrado." });

            telefoneExistente.Ativo = false;
            await _telefoneRepository.UpdateAsync(telefoneExistente);

            return (true,new List<string>());
        }

        public async Task<List<ResponseTipoTelefoneDto>> GetTiposTelefone()
        {
            var tiposTelefones = await _tipoTelefoneRepository.GetAllAsync();

            return TipoTelefoneExtensions.ToListDto(tiposTelefones);
        }
    }
}