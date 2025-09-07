using Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Domain.Interfaces
{
    public interface ITipoTelefoneRepository
    {
        Task<List<TipoTelefone>> GetAllAsync();
        Task<TipoTelefone?> GetByIdAsync(int id);
        Task<TipoTelefone> AddAsync(TipoTelefone entity);
    }
}
