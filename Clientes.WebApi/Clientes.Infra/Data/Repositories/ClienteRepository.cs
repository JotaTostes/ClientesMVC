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
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _ctx;
        public ClienteRepository(AppDbContext ctx) => _ctx = ctx;


        public async Task<Cliente?> GetByIdAsync(int id) =>
        await _ctx.Clientes.Include(c => c.Telefones).FirstOrDefaultAsync(c => c.CodigoCliente == id);


        public async Task<List<Cliente>> GetAllAsync() =>
        await _ctx.Clientes.AsNoTracking().ToListAsync();


        public async Task<Cliente> AddAsync(Cliente entity)
        {
            _ctx.Clientes.Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }


        public async Task UpdateAsync(Cliente entity)
        {
            _ctx.Clientes.Update(entity);
            await _ctx.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var e = await _ctx.Clientes.FindAsync(id);
            if (e is null) return;
            _ctx.Clientes.Remove(e);
            await _ctx.SaveChangesAsync();
        }
    }
}
