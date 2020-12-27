using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DataAccess.Configurations
{
    public class KlijentConfiguration : BaseEntityConfiguration<Klijent>
    {
        public override void Configure(EntityTypeBuilder<Klijent> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Ime).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Prezime).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Jmbg).IsRequired().HasMaxLength(13);
            builder.Property(x => x.Telefon).HasMaxLength(20);
            builder.Property(x => x.Email).HasMaxLength(100);

            builder.HasMany(x => x.Zakazivanja).WithOne(x => x.Klijent).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
