using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DataAccess.Configurations
{
    public class TerminConfiguration : BaseEntityConfiguration<Termin>
    {
        public override void Configure(EntityTypeBuilder<Termin> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Datum).IsRequired();
            builder.Property(x => x.VremePocetka).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Datum).IsRequired();

            builder.HasOne(x => x.Raspored)
               .WithMany(x => x.Termini).HasForeignKey(x => x.RasporedId).OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(x => x.ZakazivanjePregleda)
               .WithOne(x => x.Termin).HasForeignKey<ZakazivanjePregleda>(x => x.TerminId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
