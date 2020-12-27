using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DataAccess.Configurations
{
    public class ZakazivanjePregledaConfiguration : BaseEntityConfiguration<ZakazivanjePregleda>
    {
        public override void Configure(EntityTypeBuilder<ZakazivanjePregleda> builder)
        {
            builder.HasKey(x => new { x.Id, x.KlijentId, x.TipPregledaId });

            builder.Property(x => x.Napomena).HasMaxLength(1000);

        }
    }
}
