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
    public class TipoTelefoneConfig : IEntityTypeConfiguration<TipoTelefone>
    {
        public void Configure(EntityTypeBuilder<TipoTelefone> builder)
        {
            builder.HasKey(x => x.CodigoTipoTelefone);
            builder.Property(x => x.DescricaoTipoTelefone).IsRequired().HasMaxLength(50);
        }
    }
}
