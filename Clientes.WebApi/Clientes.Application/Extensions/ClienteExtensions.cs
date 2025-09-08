using Clientes.Application.DTOs.Cliente;
using Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                //Telefones = dto.Telefones.Select(t => t.ToEntity()).ToList()
            };
        }
    }
}
