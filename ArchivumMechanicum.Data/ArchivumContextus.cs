using ArchivumMechanicum.Entities.Entity_Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Data
{
    public class ArchivumContextus : IdentityDbContext
    {
        public DbSet<Location> Territorium { get; set; }

        public DbSet<Relic> Artefactum { get; set; }

        public DbSet<Record> Archivum { get; set; }

        public ArchivumContextus(DbContextOptions<ArchivumContextus> ctx)
            : base(ctx)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Movie>()
            //    .HasMany(m => m.Ratings)
            //    .WithOne(r => r.Movie)
            //    .HasForeignKey(r => r.MovieId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Location>()
                .HasMany(l => l.Relics)
                .WithOne(r => r.Location)
                .HasForeignKey(r => r.LocationIdentification)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
