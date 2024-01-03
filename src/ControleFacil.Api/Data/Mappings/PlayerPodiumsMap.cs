using ControleFacil.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFacil.Api.Data.Mappings
{
    public class PlayerPodiumsMap : IEntityTypeConfiguration<PlayerPodiums>
    {
        public void Configure(EntityTypeBuilder<PlayerPodiums> builder)
        {
            builder.ToTable("playerPodiums")
            .HasKey(p => p.Id);

            builder.Property(p => p.Place)
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