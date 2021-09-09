﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PIN_projekt_MPavlovic.Models;

namespace PIN_projekt_MPavlovic.Migrations
{
    [DbContext(typeof(Zaposlenici))]
    [Migration("20210908223329_ZaposlenikBaza")]
    partial class ZaposlenikBaza
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PIN_projekt_MPavlovic.Models.Zapo", b =>
                {
                    b.Property<int>("ZaposlenikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lokacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zvanje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZaposlenikID");

                    b.ToTable("Zaposlenik");
                });
#pragma warning restore 612, 618
        }
    }
}