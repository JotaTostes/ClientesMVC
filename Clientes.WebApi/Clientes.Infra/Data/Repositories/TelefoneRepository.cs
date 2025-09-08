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
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly AppDbContext _ctx;
        public TelefoneRepository(AppDbContext ctx) => _ctx = ctx;


        public async Task<List<Telefone>> GetByClienteAsync(Guid codigoCliente) =>
        await _ctx.Telefones.Where(t => t.CodigoCliente == codigoCliente).AsNoTracking().ToListAsync();


        public async Task<Telefone?> GetAsync(Guid codigoCliente, string numeroTelefone) =>
        await _ctx.Telefones.FindAsync(codigoCliente, numeroTelefone);


        public async Task<Telefone> AddAsync(Telefone entity)
        {
            _ctx.Telefones.Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }


        public async Task UpdateAsync(Telefone entity)
        {
            _ctx.Telefones.Update(entity);
            await _ctx.SaveChangesAsync();
        }


        public async Task DeleteAsync(Guid codigoCliente, string numeroTelefone)
        {
            var e = await _ctx.Telefones.FindAsync(codigoCliente, numeroTelefone);
            if (e is null) return;
            _ctx.Telefones.Remove(e);
            await _ctx.SaveChangesAsync();
        }
    }
}
