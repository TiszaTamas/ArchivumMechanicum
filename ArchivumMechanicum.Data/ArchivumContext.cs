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
    public class ArchivumContext : IdentityDbContext
    {
        public DbSet<Location> Locations { get; set; }

        public DbSet<Relic> Relics { get; set; }

        public DbSet<Record> Records { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public ArchivumContext(DbContextOptions<ArchivumContext> ctx)
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

            modelBuilder.Entity<Relic>()
                .HasMany(rel => rel.Records)
                .WithOne(rec=> rec.Relic)
                .HasForeignKey(rec=>rec.RelicIdentification)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Location>()
                .HasMany(l=> l.Records)
                .WithOne(r=>r.Location)
                .HasForeignKey(r=>r.LocationIdentification)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
