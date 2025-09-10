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
        public async Task<IEnumerable<ResponseClientes>> GetAllClientesAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return clientes.ToResponseDto();
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
            var cliente = await _clienteRepository.AddAsync(clienteDto.ToEntity());
            return cliente.ToResponseDto();
        }

        /// <summary>
        /// Atualiza um cliente existente e seus telefones
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

            GerenciarTelefones(existente, cliente);

            await _clienteRepository.UpdateAsync(existente);

            return (true, new List<string>());
        }

        /// <summary>
        /// Adiciona ou atualiza telefones associados ao cliente
        /// </summary>
        /// <param name="existente"></param>
        /// <param name="atualizado"></param>
        private void GerenciarTelefones(Cliente existente, Cliente atualizado)
        {
            foreach (var tel in atualizado.Telefones)
            {
                tel.NumeroTelefone = tel.NumeroTelefone.NormalizarNumero();

                var telefoneExistente = existente.Telefones.FirstOrDefault(x => x.CodigoTelefone == tel.CodigoTelefone);

                if (telefoneExistente is null)
                {
                    existente.Telefones.Add(new Telefone
                    {
                        CodigoTelefone = Guid.NewGuid(),
                        CodigoCliente = existente.CodigoCliente,
                        NumeroTelefone = tel.NumeroTelefone,
                        CodigoTipoTelefone = tel.CodigoTipoTelefone,
                        Operadora = tel.Operadora,
                        UsuarioInsercao = "ADMIN"
                    });
                }
                else
                {
                    telefoneExistente.Operadora = tel.Operadora;
                    telefoneExistente.CodigoTipoTelefone = tel.CodigoTipoTelefone;
                }
            }
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
