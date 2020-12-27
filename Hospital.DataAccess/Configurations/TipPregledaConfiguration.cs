using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DataAccess.Configurations
{
    public class TipPregledaConfiguration : BaseEntityConfiguration<TipPregleda>
    {
        public override void Configure(EntityTypeBuilder<TipPregleda> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Naziv).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Napomena).IsRequired().HasMaxLength(1000);

            builder.HasMany(x => x.DoktorTipPregleda).WithOne(x => x.TipPregleda).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Zakazivanja).WithOne(x => x.TipPregleda).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
