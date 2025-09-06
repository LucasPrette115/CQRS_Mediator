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

        builder.Property(x => x.Password)            
            .IsRequired();

        builder.Property(x => x.IsActive)    
            .IsRequired();

        builder.HasData(
                new Member(new Guid("0aa1efde-c798-40dd-b85c-a4c58cfda446"),"Carl", "Gauss", "carl.gauss@example", "6F852F607905CE1E58918A6BE99F793F0DEC1A2938D4BE901519B9D526D0FC57A0062378B42994098AB3F6208E2E8B2021AAB15D40814711701BAF8DDE22EE56-A8CF68410CABDAD5B6DC7B222D523923", "Male", true, new DateTime(2025, 09, 06), new DateTime(2025, 09, 06)),
                new Member(new Guid("60176952-afc2-4cf7-ab94-ad142d343c47"), "Leonhard", "Euler", "leonhard.euler@example", "6F852F607905CE1E58918A6BE99F793F0DEC1A2938D4BE901519B9D526D0FC57A0062378B42994098AB3F6208E2E8B2021AAB15D40814711701BAF8DDE22EE56-A8CF68410CABDAD5B6DC7B222D523923", "Male", true, new DateTime(2025, 09, 06), new DateTime(2025, 09, 06)),
                new Member(new Guid("d084a8c1-8d83-473d-8ebd-ea204adb5bfc"), "Ada", "Lovelace", "ada.lovelace@example", "6F852F607905CE1E58918A6BE99F793F0DEC1A2938D4BE901519B9D526D0FC57A0062378B42994098AB3F6208E2E8B2021AAB15D40814711701BAF8DDE22EE56-A8CF68410CABDAD5B6DC7B222D523923", "Female", true, new DateTime(2025, 09, 06), new DateTime(2025, 09, 06)),
                new Member(new Guid("4e386b6b-1fbb-409f-94f1-5ef10887a3b5"), "Marie", "Curie", "marie.curie@example", "6F852F607905CE1E58918A6BE99F793F0DEC1A2938D4BE901519B9D526D0FC57A0062378B42994098AB3F6208E2E8B2021AAB15D40814711701BAF8DDE22EE56-A8CF68410CABDAD5B6DC7B222D523923", "Female", true, new DateTime(2025, 09, 06), new DateTime(2025, 09, 06))
            );
    }
}
