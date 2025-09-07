using Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetByIdAsync(int id);
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> AddAsync(Cliente entity);
        Task UpdateAsync(Cliente entity);
        Task DeleteAsync(int id);
    }
}
