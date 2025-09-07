using Clientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Telefone> Telefones => Set<Telefone>();
        public DbSet<TipoTelefone> TiposTelefone => Set<TipoTelefone>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);


            // Seed TiposTelefone básicos
            modelBuilder.Entity<TipoTelefone>().HasData(
            new TipoTelefone { CodigoTipoTelefone = Guid.NewGuid(), DescricaoTipoTelefone = "RESIDENCIAL", UsuarioInsercao = "sistema" },
            new TipoTelefone { CodigoTipoTelefone = Guid.NewGuid(), DescricaoTipoTelefone = "COMERCIAL", UsuarioInsercao = "sistema" },
            new TipoTelefone { CodigoTipoTelefone = Guid.NewGuid(), DescricaoTipoTelefone = "WHATSAPP", UsuarioInsercao = "sistema" },
            new TipoTelefone { CodigoTipoTelefone = Guid.NewGuid(), DescricaoTipoTelefone = "CELULAR", UsuarioInsercao = "sistema" }
            );
        }
    }
}
