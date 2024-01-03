using ControleFacil.Api.Data.Mappings;
using ControleFacil.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Tournament> Tournament { get; set; }
        public DbSet<PlayerTournaments> PlayerTournaments { get; set; }
        public DbSet<PlayerPodiums> PlayerPodiums { get; set; }
        public DbSet<PlayerNorms> PlayerNorms { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TournamentMap());
            modelBuilder.ApplyConfiguration(new PlayerTournamentsMap());
            modelBuilder.ApplyConfiguration(new PlayerPodiumsMap());
            modelBuilder.ApplyConfiguration(new PlayerNormsMap());
        }
    }
}