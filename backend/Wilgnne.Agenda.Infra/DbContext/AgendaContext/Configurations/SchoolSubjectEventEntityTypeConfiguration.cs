using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wilgnne.Agenda.Domain.Entities;

namespace Wilgnne.Agenda.Infra.DbContext.AgendaContext.Configurations;

public class SchoolSubjectEventEntityTypeConfiguration : IEntityTypeConfiguration<SchoolSubjectEvent>
{
    public void Configure(EntityTypeBuilder<SchoolSubjectEvent> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Event)
            .IsRequired();

        builder
            .Property(e => e.StartEventDateTime)
            .IsRequired();
        builder
            .Property(e => e.EndEventDateTime)
            .IsRequired();

        builder
            .HasOne(e => e.Subject)
            .WithMany(e => e.SubjectEvents)
            .HasForeignKey(e => e.SchoolSubjectId);
    }
}
