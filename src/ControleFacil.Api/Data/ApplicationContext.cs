using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Data.Mappings;
using ControleFacil.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<NaturezaDeLancamento> NaturezaDeLancamento { get; set; }
        public DbSet<Apagar> Apagar { get; set; }
        public DbSet<Areceber> Areceber { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new NaturezaDeLancamentoMap());
            modelBuilder.ApplyConfiguration(new ApagarMap());
            modelBuilder.ApplyConfiguration(new AreceberMap());
        }

    }
}