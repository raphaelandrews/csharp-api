using ControleFacil.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFacil.Api.Data.Mappings
{
    public class PlayerNormsMap : IEntityTypeConfiguration<PlayerNorms>
    {
        public void Configure(EntityTypeBuilder<PlayerNorms> builder)
        {
            builder.ToTable("playerNorms")
            .HasKey(p => p.Id);

            builder.Property(p => p.Norm)
            .IsRequired();

            builder.HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId);
        }
    }
}