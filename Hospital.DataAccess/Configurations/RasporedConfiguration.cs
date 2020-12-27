using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DataAccess.Configurations
{
    public class RasporedConfiguration : BaseEntityConfiguration<Raspored>
    {
        public override void Configure(EntityTypeBuilder<Raspored> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.DatumOd).IsRequired();
            builder.Property(x => x.DatumDo).IsRequired();

            builder.HasOne(x => x.Doktor)
                .WithMany(x => x.Rasporedi)
                .HasForeignKey(x => x.DoktorId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
