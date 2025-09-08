using Clientes.Application.Interfaces;
using Clientes.Domain.Entities;
using Clientes.Domain.Interfaces;

namespace Clientes.Application.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneService(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        public async Task<List<Telefone>> GetTelefonesByClienteAsync(Guid codigoCliente)
        {
            return await _telefoneRepository.GetByClienteAsync(codigoCliente);
        }

        public async Task<(bool Success, List<string>Errors)> AddTelefoneAsync(Telefone telefone)
        {
            if (telefone == null || string.IsNullOrWhiteSpace(telefone.NumeroTelefone))
                return (false, new List<string> { "Telefone inválido." });


            var telefoneExistente = await _telefoneRepository.GetAsync(telefone.CodigoCliente, telefone.NumeroTelefone);

            if (telefoneExistente != null)
                return (false, new List<string> { "Telefone já cadastrado para este cliente." });

            await _telefoneRepository.AddAsync(telefone);
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

        public async Task<(bool Success, List<string>Errors)> RemoverTelefoneAsync(Guid codigoCliente, string numeroTelefone)
        {
            var telefoneExistente = await _telefoneRepository.GetAsync(codigoCliente, numeroTelefone);
            if (telefoneExistente == null)
                return (false, new List<string> { "Telefone não encontrado." });

            telefoneExistente.Ativo = false;
            await _telefoneRepository.UpdateAsync(telefoneExistente);

            return (true,new List<string>());
        }
    }
}