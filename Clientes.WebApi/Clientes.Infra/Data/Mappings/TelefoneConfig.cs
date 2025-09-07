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
    public class TelefoneConfig : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t => new { t.CodigoCliente, t.NumeroTelefone });
            builder.Property(t => t.NumeroTelefone).HasMaxLength(20);
            builder.Property(t => t.Operadora).HasMaxLength(30);


            builder.HasOne(t => t.TipoTelefone)
            .WithMany(tt => tt.Telefones)
            .HasForeignKey(t => t.CodigoTipoTelefone)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
