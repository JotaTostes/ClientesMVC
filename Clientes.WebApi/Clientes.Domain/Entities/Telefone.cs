using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Domain.Entities
{
    public class Telefone
    {
        public Guid CodigoTelefone { get; set; }
        public Guid CodigoCliente { get; set; }
        public string NumeroTelefone { get; set; } = string.Empty;
        public Guid CodigoTipoTelefone { get; set; }
        public string? Operadora { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataInsercao { get; set; } = DateTime.UtcNow;
        public string UsuarioInsercao { get; set; } = "admin";


        public Cliente? Cliente { get; set; }
        public TipoTelefone? TipoTelefone { get; set; }
    }
}
