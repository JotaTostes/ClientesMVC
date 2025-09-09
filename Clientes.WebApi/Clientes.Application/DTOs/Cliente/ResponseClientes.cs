using Clientes.Application.DTOs.Telefone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.DTOs.Cliente
{
    public class ResponseClientes
    {
        public Guid CodigoCliente { get; set; }
        public string NomeFantasia { get; set; }
        public string Documento { get; set; }
        public string Cidade { get; set; }
        public string RazaoSocial { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Endereco { get; set; }

        public List<ResponseTelefoneDto>? Telefones { get; set; }
    }
}
