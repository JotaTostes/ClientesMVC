using Clientes.Application.DTOs.Cliente;
using Clientes.Application.Extensions;
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
        private readonly ITelefoneRepository _telefoneRepository;

        public ClienteService(IClienteRepository clienteRepository, ITelefoneRepository telefoneRepository)
        {
            _clienteRepository = clienteRepository;
            _telefoneRepository = telefoneRepository;
        }

        /// <summary>
        /// Retorna todos os clientes cadastrados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        /// <summary>
        /// Retorna um cliente pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseClientes?> GetClienteByIdAsync(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            return cliente?.ToResponseDto();
        }

        /// <summary>
        /// Adiciona um novo cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<ResponseClientes> AddClienteAsync(CreateClienteDto clienteDto)
        {
            var cliente = await _clienteRepository.AddAsync(ClienteExtensions.ToEntity(clienteDto));
            return cliente.ToResponseDto();
        }

        /// <summary>
        /// Atualiza um cliente existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<(bool Success, List<string>Errors)> UpdateClienteAsync(Guid id, Cliente cliente)
        {
            var existente = await _clienteRepository.GetByIdAsync(id);
            if (existente == null)
            {
                return (false, new List<string> { "Cliente não encontrado." });
            }

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

            return (true, new List<string>());
        }

        /// <summary>
        /// Deleta um cliente pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<(bool Success, List<string>Errors)> DeleteClienteAsync(Guid id)
        {
            var clienteDeletar = await _clienteRepository.GetByIdAsync(id);
            if (clienteDeletar == null)
                return (false, new List<string> { "Cliente não encontrado." });

            await _clienteRepository.DeleteAsync(clienteDeletar);

            return (true, new List<string>());
        }
    }
}
