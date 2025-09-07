using System.ComponentModel.DataAnnotations;

namespace Clientes.Mvc.Models
{
    public class TelefoneViewModel
    {
        public Guid CodigoCliente { get; set; }

        [Required, StringLength(20)]
        public string NumeroTelefone { get; set; }

        [Required]
        public int CodigoTipoTelefone { get; set; }

        public string Operadora { get; set; }
        public bool Ativo { get; set; }

        public DateTime DataInsercao { get; set; }
        public string UsuarioInsercao { get; set; }

        // Info auxiliar
        public string DescricaoTipoTelefone { get; set; }
    }
}
