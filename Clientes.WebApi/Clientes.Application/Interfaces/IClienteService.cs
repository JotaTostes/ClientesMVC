using Clientes.Application.DTOs.Cliente;
using Clientes.Domain.Entities;


namespace Clientes.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ResponseClientes>> GetAllClientesAsync();
        Task<ResponseClientes?> GetClienteByIdAsync(Guid id);
        Task<ResponseClientes> AddClienteAsync(CreateClienteDto clienteDto);
        Task<(bool Success, List<string> Errors)> UpdateClienteAsync(Guid id, Cliente cliente);
        Task<(bool Success, List<string> Errors)> DeleteClienteAsync(Guid id);
    }
}
