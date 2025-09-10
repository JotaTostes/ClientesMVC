using Clientes.Application.DTOs.Telefone;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.DTOs.Cliente
{
    public class UpdateClienteDto
    {
        [Required(ErrorMessage = "Razão Social é obrigatória")]
        [StringLength(200, ErrorMessage = "Razão Social deve ter no máximo 200 caracteres")]
        public string RazaoSocial { get; set; }

        [StringLength(200, ErrorMessage = "Nome Fantasia deve ter no máximo 200 caracteres")]
        public string NomeFantasia { get; set; }

        public string TipoPessoa { get; set; }

        [Required(ErrorMessage = "Documento é obrigatório")]
        [StringLength(18, ErrorMessage = "Documento deve ter no máximo 18 caracteres")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [StringLength(300, ErrorMessage = "Endereço deve ter no máximo 300 caracteres")]
        public string Endereco { get; set; }

        [StringLength(100, ErrorMessage = "Complemento deve ter no máximo 100 caracteres")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        [StringLength(100, ErrorMessage = "Bairro deve ter no máximo 100 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatória")]
        [StringLength(100, ErrorMessage = "Cidade deve ter no máximo 100 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório")]
        [RegularExpression(@"^\d{5}-?\d{3}$", ErrorMessage = "CEP deve estar no formato 00000-000")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "UF é obrigatório")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "UF deve ter exatamente 2 caracteres")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Usuário de inserção é obrigatório")]
        [StringLength(50, ErrorMessage = "Usuário de inserção deve ter no máximo 50 caracteres")]
        public string UsuarioInsercao { get; set; }

        public List<UpdateTelefoneDto> Telefones { get; set; }
    }
}
