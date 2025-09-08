using Clientes.Domain.Entities;
using System.Threading.Tasks;

namespace Clientes.Application.Interfaces
{
    public interface ITelefoneService
    {
        Task<List<Telefone>> GetTelefonesByClienteAsync(Guid codigoCliente);
        Task<(bool Success, List<string> Errors)> AddTelefoneAsync(Telefone telefone);
        Task<(bool Success, List<string> Errors)> UpdateTelefoneAsync(Guid codigoCliente, Telefone telefone);
        Task<(bool Success, List<string> Errors)> RemoverTelefoneAsync(Guid codigoCliente, string numeroTelefone);
    }
}
