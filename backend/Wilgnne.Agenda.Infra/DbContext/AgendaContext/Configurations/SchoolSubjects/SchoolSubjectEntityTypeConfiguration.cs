using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wilgnne.Agenda.Domain.Entities;

namespace Wilgnne.Agenda.Infra.DbContext.AgendaContext.Configurations.SchoolSubjects;

public class SchoolSubjectEntityTypeConfiguration : IEntityTypeConfiguration<SchoolSubject>
{
    public void Configure(EntityTypeBuilder<SchoolSubject> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Subject)
            .IsRequired();

        builder
            .HasMany(e => e.SubjectEvents)
            .WithOne(e => e.Subject)
            .HasForeignKey((e) => e.SchoolSubjectId);

        builder
            .HasOne(e => e.User)
            .WithMany(e => e.SchoolSubjects)
            .HasForeignKey(e => e.UserId);
    }
}
