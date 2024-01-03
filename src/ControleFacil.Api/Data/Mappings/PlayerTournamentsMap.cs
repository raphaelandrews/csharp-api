using ControleFacil.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFacil.Api.Data.Mappings
{
    public class PlayerTournamentsMap : IEntityTypeConfiguration<PlayerTournaments>
    {
        public void Configure(EntityTypeBuilder<PlayerTournaments> builder)
        {
            builder.ToTable("playerTournaments")
            .HasKey(p => p.Id);

            builder.Property(p => p.RatingType)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(p => p.OldRating)
            .IsRequired();

            builder.Property(p => p.Variation)
            .IsRequired();

            builder.HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Tournament)
            .WithMany()
            .HasForeignKey(p => p.TournamentId);
        }
    }
}