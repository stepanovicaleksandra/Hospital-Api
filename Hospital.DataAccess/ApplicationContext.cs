using Hospital.DataAccess.Configurations;
using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Hospital.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public virtual DbSet<Doktor> Doktori { get; set; }

        public virtual DbSet<Raspored> Rasporedi { get; set; }

        public virtual DbSet<Termin> Termini { get; set; }

        public virtual DbSet<Klijent> Klijenti { get; set; }

        public virtual DbSet<TipPregleda> TipoviPregleda { get; set; }

        public virtual DbSet<ZakazivanjePregleda> ZakazivanjaPregleda { get; set; }
        public virtual DbSet<DoktorTipPregleda> DoktorTipPregleda { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                builder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }

            builder.ApplyConfiguration(new DoktorConfiguration());

            builder.ApplyConfiguration(new RasporedConfiguration());

            builder.ApplyConfiguration(new TerminConfiguration());

            builder.ApplyConfiguration(new KlijentConfiguration());

            builder.ApplyConfiguration(new TipPregledaConfiguration());

            builder.ApplyConfiguration(new ZakazivanjePregledaConfiguration());

            builder.ApplyConfiguration(new DoktorTipPregledaConfiguration());


        }
    }
}
