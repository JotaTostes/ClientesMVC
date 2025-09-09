using Clientes.Application.DTOs.Cliente;
using Clientes.Application.DTOs.Telefone;
using Clientes.Domain.Entities;


namespace Clientes.Application.Extensions
{
    public static class ClienteExtensions
    {
        public static Cliente ToEntity(this CreateClienteDto dto)
        {
            return new Cliente
            {
                RazaoSocial = dto.RazaoSocial,
                NomeFantasia = dto.NomeFantasia,
                TipoPessoa = dto.TipoPessoa,
                Documento = dto.Documento,
                Endereco = dto.Endereco,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                CEP = dto.CEP,
                UF = dto.UF,
                DataInsercao = DateTime.UtcNow,
                UsuarioInsercao = dto.UsuarioInsercao,
                Telefones = dto.Telefones.Select(t => t.ToEntity()).ToList()
            };
        }

        public static ResponseClientes ToResponseDto(this Cliente entity)
        {
            return new ResponseClientes
            {
                CodigoCliente = entity.CodigoCliente,
                Cidade = entity.Cidade,
                Documento = entity.Documento,
                NomeFantasia = entity.NomeFantasia,
                Bairro = entity.Bairro,
                Cep = entity.CEP,
                Complemento = entity.Complemento ?? string.Empty,
                Endereco = entity.Endereco,
                RazaoSocial = entity.RazaoSocial,
                Uf = entity.UF,
                Telefones = entity.Telefones?.Select(t => t.ToResponseDto()).ToList() ?? new List<ResponseTelefoneDto>()
            };
        }
    }
}
