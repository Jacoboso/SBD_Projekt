using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SBD_Projekt.Models
{
    public class SBD_ProjektContext : DbContext
    {
        public SBD_ProjektContext (DbContextOptions<SBD_ProjektContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<SBD_Projekt.Models.Osoba> Osoba { get; set; }
        public DbSet<SBD_Projekt.Models.Adres> Adres { get; set; }
        public DbSet<SBD_Projekt.Models.Prawnik> Prawnik { get; set; }
        public DbSet<SBD_Projekt.Models.Rozprawa> Rozprawa { get; set; }
        public DbSet<SBD_Projekt.Models.Sedzia> Sedzia { get; set; }
        public DbSet<SBD_Projekt.Models.Wydzial> Wydzial { get; set; }
        public DbSet<SBD_Projekt.Models.Budynek> Budynek { get; set; }
        public DbSet<SBD_Projekt.Models.Dowod> Dowod { get; set; }
        public DbSet<SBD_Projekt.Models.Godziny> Godziny { get; set; }

        public DbSet<SBD_Projekt.Models.Zarobki> Zarobki { get; set; }
        public DbSet<SBD_Projekt.Models.Klient> Klient { get; set; }
        public DbSet<SBD_Projekt.Models.Spotkanie> Spotkanie { get; set; }
        public DbSet<SBD_Projekt.Models.Sala> Sala { get; set; }
        public DbSet<SBD_Projekt.Models.Specjalizacja> Specjalizacja { get; set; }
        public DbSet<SBD_Projekt.Models.Obsluga> Obsluga { get; set; }
    }
}
