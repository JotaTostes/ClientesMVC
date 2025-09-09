using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.DTOs.TipoTelefone
{
    public class ResponseTipoTelefoneDto
    {
        public Guid CodigoTipoTelefone { get; set; }
        public string Descricao { get; set; }
    }
}
