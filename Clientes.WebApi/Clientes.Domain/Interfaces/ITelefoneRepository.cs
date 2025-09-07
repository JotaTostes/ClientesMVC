using Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Domain.Interfaces
{
    public interface ITelefoneRepository
    {
        Task<List<Telefone>> GetByClienteAsync(int codigoCliente);
        Task<Telefone?> GetAsync(int codigoCliente, string numeroTelefone);
        Task<Telefone> AddAsync(Telefone entity);
        Task UpdateAsync(Telefone entity);
        Task DeleteAsync(int codigoCliente, string numeroTelefone);
    }
}
