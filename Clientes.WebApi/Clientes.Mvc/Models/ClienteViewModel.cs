using System.ComponentModel.DataAnnotations;

namespace Clientes.Mvc.Models
{
    public class ClienteViewModel
    {
        public Guid CodigoCliente { get; set; }

        [Required, StringLength(200)]
        public string RazaoSocial { get; set; }

        [Required, StringLength(200)]
        public string NomeFantasia { get; set; }

        [Required]
        public string TipoPessoa { get; set; } // F/J

        [Required, StringLength(20)]
        public string Documento { get; set; }

        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }

        public DateTime DataInsercao { get; set; }
        public string UsuarioInsercao { get; set; }

        public List<TelefoneViewModel> Telefones { get; set; } = new();
    }
}
