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
    }
}
