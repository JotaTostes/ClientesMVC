using Clientes.Application.Interfaces;
using Clientes.Domain.Entities;
using Clientes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }
        public async Task<Cliente?> GetClienteByIdAsync(Guid id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }
        public async Task<Cliente> AddClienteAsync(Cliente cliente)
        {
            cliente.UsuarioInsercao = "sistema";

            return await _clienteRepository.AddAsync(cliente);
        }
        public async Task<bool> UpdateClienteAsync(Guid id, Cliente cliente)
        {
            var existente = await _clienteRepository.GetByIdAsync(id);
            if (existente == null)
                return false;


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

            await _clienteRepository.UpdateAsync(existente);

            return true;
        }
        public async Task<bool> DeleteClienteAsync(Guid id)
        {
            var clienteDeletar = await _clienteRepository.GetByIdAsync(id);
            if (clienteDeletar == null)
                return false;

            await _clienteRepository.DeleteAsync(clienteDeletar);
            return true;
        }
    }
}
