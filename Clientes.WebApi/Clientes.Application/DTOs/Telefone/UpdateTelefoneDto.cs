using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.DTOs.Telefone
{
    public class UpdateTelefoneDto
    {
        [RegularExpression(@"^\d{8,9}$", ErrorMessage = "Número deve conter 8 ou 9 dígitos")]
        public string NumeroTelefone { get; set; } = string.Empty;
        public string Operadora { get; set; }
        public Guid CodigoTipoTelefone { get; set; }
    }
}
