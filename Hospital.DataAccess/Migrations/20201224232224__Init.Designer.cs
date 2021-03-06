﻿// <auto-generated />
using System;
using Hospital.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201224232224__Init")]
    partial class _Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Hospital.Domain.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Jmbg")
                        .HasMaxLength(13)
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Specijalnost")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Doktor");
                });

            modelBuilder.Entity("Hospital.Domain.DoktorTipPregleda", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("TipPregledaId")
                        .HasColumnType("int");

                    b.HasKey("Id", "DoktorId", "TipPregledaId");

                    b.HasIndex("DoktorId");

                    b.HasIndex("TipPregledaId");

                    b.ToTable("DoktorTipPregleda");
                });

            modelBuilder.Entity("Hospital.Domain.Klijent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Jmbg")
                        .HasMaxLength(13)
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefon")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Klijent");
                });

            modelBuilder.Entity("Hospital.Domain.Raspored", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DatumDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumOd")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.ToTable("Raspored");
                });

            modelBuilder.Entity("Hospital.Domain.Termin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("RasporedId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("VremePocetka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VremeZavrsetka")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ZakazivanjePregledaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RasporedId");

                    b.ToTable("Termin");
                });

            modelBuilder.Entity("Hospital.Domain.TipPregleda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Napomena")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipPregleda");
                });

            modelBuilder.Entity("Hospital.Domain.ZakazivanjePregleda", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("KlijentId")
                        .HasColumnType("int");

                    b.Property<int>("TipPregledaId")
                        .HasColumnType("int");

                    b.Property<string>("Napomena")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("RasporedId")
                        .HasColumnType("int");

                    b.Property<int>("TerminId")
                        .HasColumnType("int");

                    b.HasKey("Id", "KlijentId", "TipPregledaId");

                    b.HasIndex("KlijentId");

                    b.HasIndex("RasporedId");

                    b.HasIndex("TerminId")
                        .IsUnique();

                    b.HasIndex("TipPregledaId");

                    b.ToTable("ZakazivanjePregleda");
                });

            modelBuilder.Entity("Hospital.Domain.DoktorTipPregleda", b =>
                {
                    b.HasOne("Hospital.Domain.Doktor", "Doktor")
                        .WithMany("DoktorTipPregleda")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Domain.TipPregleda", "TipPregleda")
                        .WithMany("DoktorTipPregleda")
                        .HasForeignKey("TipPregledaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("TipPregleda");
                });

            modelBuilder.Entity("Hospital.Domain.Raspored", b =>
                {
                    b.HasOne("Hospital.Domain.Doktor", "Doktor")
                        .WithMany("Rasporedi")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doktor");
                });

            modelBuilder.Entity("Hospital.Domain.Termin", b =>
                {
                    b.HasOne("Hospital.Domain.Raspored", "Raspored")
                        .WithMany("Termini")
                        .HasForeignKey("RasporedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Raspored");
                });

            modelBuilder.Entity("Hospital.Domain.ZakazivanjePregleda", b =>
                {
                    b.HasOne("Hospital.Domain.Klijent", "Klijent")
                        .WithMany("Zakazivanja")
                        .HasForeignKey("KlijentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Hospital.Domain.Raspored", "Raspored")
                        .WithMany()
                        .HasForeignKey("RasporedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Domain.Termin", "Termin")
                        .WithOne("ZakazivanjePregleda")
                        .HasForeignKey("Hospital.Domain.ZakazivanjePregleda", "TerminId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Hospital.Domain.TipPregleda", "TipPregleda")
                        .WithMany("Zakazivanja")
                        .HasForeignKey("TipPregledaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Klijent");

                    b.Navigation("Raspored");

                    b.Navigation("Termin");

                    b.Navigation("TipPregleda");
                });

            modelBuilder.Entity("Hospital.Domain.Doktor", b =>
                {
                    b.Navigation("DoktorTipPregleda");

                    b.Navigation("Rasporedi");
                });

            modelBuilder.Entity("Hospital.Domain.Klijent", b =>
                {
                    b.Navigation("Zakazivanja");
                });

            modelBuilder.Entity("Hospital.Domain.Raspored", b =>
                {
                    b.Navigation("Termini");
                });

            modelBuilder.Entity("Hospital.Domain.Termin", b =>
                {
                    b.Navigation("ZakazivanjePregleda");
                });

            modelBuilder.Entity("Hospital.Domain.TipPregleda", b =>
                {
                    b.Navigation("DoktorTipPregleda");

                    b.Navigation("Zakazivanja");
                });
#pragma warning restore 612, 618
        }
    }
}
