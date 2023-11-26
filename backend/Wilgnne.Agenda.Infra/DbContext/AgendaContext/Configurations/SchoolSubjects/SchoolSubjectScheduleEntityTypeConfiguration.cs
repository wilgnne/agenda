using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wilgnne.Agenda.Domain.Entities;
using Wilgnne.Agenda.Infra.Extensions;

namespace Wilgnne.Agenda.Infra.DbContext.AgendaContext.Configurations.SchoolSubjects;

public class SchoolSubjectScheduleEntityTypeConfiguration : IEntityTypeConfiguration<SchoolSubjectSchedule>
{
    public void Configure(EntityTypeBuilder<SchoolSubjectSchedule> builder)
    {
        builder
           .HasKey(e => e.Id);

        builder
            .Property(e => e.WeekDay)
            .IsRequired()
            .HasConversion<int>();

        builder
            .Property(e => e.StartTime)
            .HasConversion<TimeOnlyConverter>()
            .HasColumnType("time");

        builder
            .Property(e => e.EndTime)
            .HasConversion<TimeOnlyConverter>()
            .HasColumnType("time");

        builder
            .HasOne(e => e.WeekSetting)
            .WithMany(e => e.SubjectSchedules)
            .HasForeignKey(e => e.WeekSettingId);
    }
}
