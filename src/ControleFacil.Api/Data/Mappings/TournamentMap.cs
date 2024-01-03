using ControleFacil.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFacil.Api.Data.Mappings
{
    public class TournamentMap : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.ToTable("tournament")
            .HasKey(p => p.Id);

            builder.Property(p => p.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired();

            builder.Property(p => p.ChessResults)
            .HasColumnType("VARCHAR")
            .HasMaxLength(400)
            .IsRequired();

            builder.Property(p => p.Date)
            .HasColumnType("timestamp")
            .IsRequired();

            builder.HasMany(p => p.PlayerPodiums)
            .WithOne(p => p.Tournament)
            .HasForeignKey(p => p.TournamentId);

            builder.HasMany(p => p.PlayerTournaments)
            .WithOne(p => p.Tournament)
            .HasForeignKey(p => p.TournamentId);
        }
    }
}