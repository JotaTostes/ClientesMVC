using Clientes.Domain.Entities;
using Clientes.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Infra.Data.Repositories
{
    public class TipoTelefoneRepository : ITipoTelefoneRepository
    {
        private readonly AppDbContext _ctx;
        public TipoTelefoneRepository(AppDbContext ctx) => _ctx = ctx;


        public async Task<List<TipoTelefone>> GetAllAsync() =>
            await _ctx.TiposTelefone.AsNoTracking().ToListAsync();

        public async Task<TipoTelefone?> GetByIdAsync(int id) =>
            await _ctx.TiposTelefone.FindAsync(id);

        public async Task<TipoTelefone> AddAsync(TipoTelefone entity)
        {
            _ctx.TiposTelefone.Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }
    }
}
