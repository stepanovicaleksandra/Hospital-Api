using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DataAccess.Configurations
{
    public class DoktorTipPregledaConfiguration : BaseEntityConfiguration<DoktorTipPregleda>
    {
        public override void Configure(EntityTypeBuilder<DoktorTipPregleda> builder)
        {
            builder.HasKey(x => new { x.Id, x.DoktorId, x.TipPregledaId });

        }
    }
}
