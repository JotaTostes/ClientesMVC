using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Domain.Entities
{
    public class Cliente
    {
        public Guid CodigoCliente { get; set; } = Guid.NewGuid();
        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string TipoPessoa { get; set; } = "J"; // J=Jurídica, F=Física
        public string Documento { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string? Complemento { get; set; }
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public DateTime DataInsercao { get; set; } = DateTime.UtcNow;
        public string UsuarioInsercao { get; set; } = string.Empty;


        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
    }
}
