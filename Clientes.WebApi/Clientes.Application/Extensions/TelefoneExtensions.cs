using Clientes.Application.DTOs.Telefone;
using Clientes.Application.DTOs.TipoTelefone;
using Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Extensions
{
    public static class TelefoneExtensions
    {
        public static List<Telefone>? ToListEntity(this List<CreateTelefoneDto> dto)
        {
            return dto?
                .Select(e => new Telefone
                {
                    CodigoCliente = e.CodigoCliente,
                    CodigoTipoTelefone = e.CodigoTipoTelefone,
                    NumeroTelefone = e.NumeroTelefone,
                    Operadora = e.Operadora,
                }).ToList();
        }

        public static Telefone ToEntity(this CreateTelefoneDto dto)
        {
            return new Telefone
            {
                CodigoCliente = dto.CodigoCliente,
                CodigoTipoTelefone = dto.CodigoTipoTelefone,
                NumeroTelefone = dto.NumeroTelefone,
                Operadora = dto.Operadora,
            };
        }

        public static ResponseTelefoneDto ToResponseDto(this Telefone entity)
        {
            return new ResponseTelefoneDto
            {
                CodigoTipoTelefone = entity.CodigoTipoTelefone,
                NumeroTelefone = entity.NumeroTelefone,
                Operadora = entity.Operadora,
            };
        }

    }
}
