using Clientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Infra.Data.Mappings
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.CodigoCliente);
            builder.Property(x => x.RazaoSocial).IsRequired().HasMaxLength(200);
            builder.Property(x => x.NomeFantasia).HasMaxLength(200);
            builder.Property(x => x.TipoPessoa).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Documento).IsRequired().HasMaxLength(18);
            builder.Property(x => x.CEP).HasMaxLength(9);
            builder.Property(x => x.UF).HasMaxLength(2).IsRequired();


            builder.HasMany(x => x.Telefones)
            .WithOne(t => t.Cliente!)
            .HasForeignKey(t => t.CodigoCliente)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
