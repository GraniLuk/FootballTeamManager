using FootballManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamPlayerAssociation> TeamPlayerAssociations { get; set; }
        public DbSet<Ranking> Ranking { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Fixture>().ToTable("Fixtures");
            modelBuilder.Entity<Player>().ToTable("Players");
            modelBuilder.Entity<Team>().ToTable("Teams");
            modelBuilder.Entity<TeamPlayerAssociation>().ToTable("TeamPlayerAssociations");
            modelBuilder.Entity<Ranking>().ToTable("Rankings");
        }
    }
}
