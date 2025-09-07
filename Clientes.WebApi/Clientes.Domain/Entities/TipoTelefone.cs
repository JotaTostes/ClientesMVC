using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Domain.Entities
{
    public class TipoTelefone
    {
        public Guid CodigoTipoTelefone { get; set; }
        public string DescricaoTipoTelefone { get; set; } = string.Empty;
        public DateTime DataInsercao { get; set; } = DateTime.UtcNow;
        public string UsuarioInsercao { get; set; } = string.Empty;


        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
    }
}
