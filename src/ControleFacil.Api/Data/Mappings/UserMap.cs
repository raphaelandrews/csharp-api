using ControleFacil.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFacil.Api.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user")
            .HasKey(p => p.Id);

            builder.Property(p => p.Email)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(p => p.Password)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(p => p.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired();

            builder.Property(p => p.Nickname)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(p => p.Avatar)
            .HasColumnType("VARCHAR");

            builder.Property(p => p.Description)
            .HasMaxLength(200)
            .HasColumnType("VARCHAR");

            builder.Property(p => p.Role)
            .HasColumnType("VARCHAR");

            builder.Property(p => p.Blitz)
            .HasDefaultValue(1900);

            builder.Property(p => p.Rapid)
            .HasDefaultValue(1900);

            builder.Property(p => p.Classic)
            .HasDefaultValue(1900);

            builder.Property(p => p.Title)
            .HasMaxLength(50)
            .HasColumnType("VARCHAR");

            builder.Property(p => p.ShortTitle)
            .HasMaxLength(5)
            .HasColumnType("VARCHAR");

            builder.Property(p => p.City)
            .HasMaxLength(100)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(p => p.Birth)
            .HasColumnType("timestamp")
            .IsRequired();

            builder.Property(p => p.CbxId);

            builder.Property(p => p.FideId);

            builder.Property(p => p.Active);

            builder.HasMany(p => p.PlayerNorms)
            .WithOne(pn => pn.User)
            .HasForeignKey(pn => pn.UserId);

            builder.HasMany(p => p.PlayerPodiums)
            .WithOne(pn => pn.User)
            .HasForeignKey(pn => pn.UserId);

            builder.HasMany(p => p.PlayerTournaments)
            .WithOne(pn => pn.User)
            .HasForeignKey(pn => pn.UserId);

            builder.Property(p => p.CreatedAt)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

            builder.Property(p => p.UpdatedAt)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
        }
    }
}