using Clientes.Application.DTOs.Cliente;
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
        Task<Cliente> AddClienteAsync(CreateClienteDto cliente);
        Task<(bool Success, List<string> Errors)> UpdateClienteAsync(Guid id, Cliente cliente);
        Task<(bool Success, List<string> Errors)> DeleteClienteAsync(Guid id);
    }
}
