using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.EntityConfiguration;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Gender)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.IsActive)    
            .IsRequired();

        builder.HasData(
                new Member("Carl", "Gauss", "carl.gauss@example", "Male", true),
                new Member("Leonhard", "Euler", "leonhard.euler@example", "Male", true),
                new Member("Ada", "Lovelace", "ada.lovelace@example", "Female", true),
                new Member("Marie", "Curie", "marie.curie@example", "Female", true)
            );
    }
}
