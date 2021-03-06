﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SBD_Projekt.Models;

namespace SBD_Projekt.Migrations
{
    [DbContext(typeof(SBD_ProjektContext))]
    partial class SBD_ProjektContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SBD_Projekt.Models.Adres", b =>
                {
                    b.Property<int>("id_adres")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kraj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nr_domu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nr_miszkania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Województwo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_adres");

                    b.ToTable("Adres");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Budynek", b =>
                {
                    b.Property<int>("id_budynek")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KodPocztowy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrBudynku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_budynek");

                    b.ToTable("Budynek");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Dowod", b =>
                {
                    b.Property<int>("id_dowod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Typ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_dowod");

                    b.ToTable("Dowod");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Godziny", b =>
                {
                    b.Property<int>("id_godziny")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DoGodziny")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OdGodziny")
                        .HasColumnType("datetime2");

                    b.HasKey("id_godziny");

                    b.ToTable("Godziny");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Klient", b =>
                {
                    b.Property<int>("id_klient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_osoba")
                        .HasColumnType("int");

                    b.Property<int>("id_prawnik")
                        .HasColumnType("int");

                    b.HasKey("id_klient");

                    b.ToTable("Klient");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Obsluga", b =>
                {
                    b.Property<int>("id_obsluga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_godziny")
                        .HasColumnType("int");

                    b.Property<int>("id_osoba")
                        .HasColumnType("int");

                    b.Property<int>("id_zarobki")
                        .HasColumnType("int");

                    b.Property<string>("typ")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_obsluga");

                    b.ToTable("Obsluga");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Osoba", b =>
                {
                    b.Property<int>("id_osoba")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<int>("id_adres")
                        .HasColumnType("int");

                    b.HasKey("id_osoba");

                    b.ToTable("Osoba");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Prawnik", b =>
                {
                    b.Property<int>("id_prawnik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_godziny")
                        .HasColumnType("int");

                    b.Property<int>("id_osoba")
                        .HasColumnType("int");

                    b.Property<int>("id_specjalizacja")
                        .HasColumnType("int");

                    b.Property<int>("id_zarobki")
                        .HasColumnType("int");

                    b.HasKey("id_prawnik");

                    b.ToTable("Prawnik");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Rozprawa", b =>
                {
                    b.Property<int>("id_rozprawa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_dowod")
                        .HasColumnType("int");

                    b.Property<int>("id_godziny")
                        .HasColumnType("int");

                    b.Property<int>("id_klient")
                        .HasColumnType("int");

                    b.Property<int>("id_prawnik")
                        .HasColumnType("int");

                    b.Property<int>("id_sedzia")
                        .HasColumnType("int");

                    b.Property<int>("id_wydzial")
                        .HasColumnType("int");

                    b.HasKey("id_rozprawa");

                    b.ToTable("Rozprawa");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Sala", b =>
                {
                    b.Property<int>("id_sala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Rodzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wielkosc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_sala");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Sedzia", b =>
                {
                    b.Property<int>("id_sedzia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_osoba")
                        .HasColumnType("int");

                    b.Property<int>("id_wydzial")
                        .HasColumnType("int");

                    b.Property<int>("id_zarobki")
                        .HasColumnType("int");

                    b.HasKey("id_sedzia");

                    b.ToTable("Sedzia");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Specjalizacja", b =>
                {
                    b.Property<int>("id_specjalizacja")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("doswiadczenie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_specjalizacja");

                    b.ToTable("Specjalizacja");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Spotkanie", b =>
                {
                    b.Property<int>("id_spotkanie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_godziny")
                        .HasColumnType("int");

                    b.Property<int>("id_klient")
                        .HasColumnType("int");

                    b.Property<int>("id_prawnik")
                        .HasColumnType("int");

                    b.Property<int>("id_sali")
                        .HasColumnType("int");

                    b.HasKey("id_spotkanie");

                    b.ToTable("Spotkanie");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Wydzial", b =>
                {
                    b.Property<int>("id_wydzial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_budynku")
                        .HasColumnType("int");

                    b.Property<string>("nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_wydzial");

                    b.ToTable("Wydzial");
                });

            modelBuilder.Entity("SBD_Projekt.Models.Zarobki", b =>
                {
                    b.Property<int>("id_zarobki")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("premia")
                        .HasColumnType("real");

                    b.Property<float>("zarobek")
                        .HasColumnType("real");

                    b.HasKey("id_zarobki");

                    b.ToTable("Zarobki");
                });
#pragma warning restore 612, 618
        }
    }
}
