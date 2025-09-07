using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Domain.Entities
{
    public class Telefone
    {
        public Guid CodigoCliente { get; set; }
        public string NumeroTelefone { get; set; } = string.Empty;
        public int CodigoTipoTelefone { get; set; }
        public string? Operadora { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataInsercao { get; set; } = DateTime.UtcNow;
        public string UsuarioInsercao { get; set; } = string.Empty;


        public Cliente? Cliente { get; set; }
        public TipoTelefone? TipoTelefone { get; set; }
    }
}
