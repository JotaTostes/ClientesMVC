using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.DTOs.Telefone
{
    public class ResponseTelefoneDto
    {
        public Guid CodigoTelefone { get; set; }
        public string NumeroTelefone { get; set; }
        public Guid CodigoTipoTelefone { get; set; }
        public string? Operadora { get; set; }
    }
}
