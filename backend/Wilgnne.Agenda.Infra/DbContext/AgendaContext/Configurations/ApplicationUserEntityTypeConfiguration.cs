using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wilgnne.Agenda.Domain.Entities;

namespace Wilgnne.Agenda.Infra.DbContext.AgendaContext.Configurations;

public class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Email)
            .IsRequired();

        builder
            .Property(e => e.FirebaseUserId)
            .IsRequired();

        builder
            .HasIndex(e => e.Email)
            .IsUnique();
    }
}
