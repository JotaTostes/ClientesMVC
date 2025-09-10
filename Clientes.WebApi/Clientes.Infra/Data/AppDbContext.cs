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
            new TipoTelefone { CodigoTipoTelefone = new Guid("0e481610-8420-410f-b02b-3ea66b39d854"), DescricaoTipoTelefone = "RESIDENCIAL", UsuarioInsercao = "sistema" },
            new TipoTelefone { CodigoTipoTelefone = new Guid("858dd8c5-921a-4a0b-aaeb-3293e4afcf05"), DescricaoTipoTelefone = "COMERCIAL", UsuarioInsercao = "sistema" },
            new TipoTelefone { CodigoTipoTelefone = new Guid("FBE917E7-5D43-44CB-B375-E3CBE44E3D42"), DescricaoTipoTelefone = "WHATSAPP",UsuarioInsercao = "sistema" },
            new TipoTelefone { CodigoTipoTelefone = new Guid("1aaae748-3a5a-496e-8626-9692d277e1da"), DescricaoTipoTelefone = "CELULAR", UsuarioInsercao = "sistema" }
            );
        }
    }
}
