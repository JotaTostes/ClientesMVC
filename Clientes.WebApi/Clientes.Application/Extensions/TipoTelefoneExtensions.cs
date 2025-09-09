using Clientes.Application.DTOs.Cliente;
using Clientes.Application.DTOs.TipoTelefone;
using Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Extensions
{
    public static class TipoTelefoneExtensions
    {
        public static List<ResponseTipoTelefoneDto>? ToListDto(this List<TipoTelefone> entities)
        {
            return entities?
                .Select(e => new ResponseTipoTelefoneDto
                {
                    CodigoTipoTelefone = e.CodigoTipoTelefone,
                    Descricao = e.DescricaoTipoTelefone
                })
                .ToList();
        }
    }
}
