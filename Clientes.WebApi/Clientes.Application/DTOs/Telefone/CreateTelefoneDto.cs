using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.DTOs.Telefone
{
    public class CreateTelefoneDto
    {
        public Guid CodigoCliente { get; set; }
        public string NumeroTelefone { get; set; }
        public Guid CodigoTipoTelefone { get; set; }
        public string? Operadora { get; set; }
        public string UsuarioInsercao { get; set; } = "ADMIN";
    }
}
