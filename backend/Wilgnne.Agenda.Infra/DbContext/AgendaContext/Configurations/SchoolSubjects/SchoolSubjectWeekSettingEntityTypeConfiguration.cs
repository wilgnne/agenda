using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wilgnne.Agenda.Domain.Entities;

namespace Wilgnne.Agenda.Infra.DbContext.AgendaContext.Configurations.SchoolSubjects;

public class SchoolSubjectWeekSettingEntityTypeConfiguration : IEntityTypeConfiguration<SchoolSubjectWeekSetting>
{
    public void Configure(EntityTypeBuilder<SchoolSubjectWeekSetting> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Order)
            .IsRequired();

        builder
            .HasOne(e => e.SchoolSubject)
            .WithMany(e => e.WeekSettings)
            .HasForeignKey(e => e.SchoolSubjectId);

        builder
            .HasMany(e => e.SubjectSchedules)
            .WithOne(e => e.WeekSetting)
            .HasForeignKey(e => e.WeekSettingId);
    }
}
