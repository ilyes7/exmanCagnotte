using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
   public class ExamenContext:DbContext
    {
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<Cagnotte> Cagnottes { get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=CagDB;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var prop in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.Name.StartsWith("Mail"))
                )
            {
                prop.IsNullable = false;
            }
            modelBuilder.Entity<Participation>().HasKey(p => new { p.CagnotteFk, p.ParticipantFk });
            base.OnModelCreating(modelBuilder);


        }
    }
}
