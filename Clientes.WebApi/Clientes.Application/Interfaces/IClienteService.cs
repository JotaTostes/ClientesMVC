using Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetAllClientesAsync();
        Task<Cliente?> GetClienteByIdAsync(Guid id);
        Task<Cliente> AddClienteAsync(Cliente cliente);
        Task<bool> UpdateClienteAsync(Guid id, Cliente cliente);
        Task<bool> DeleteClienteAsync(Guid id);
    }
}
