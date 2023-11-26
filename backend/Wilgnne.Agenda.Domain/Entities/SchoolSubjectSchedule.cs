using Wilgnne.Agenda.Domain.Enums;

namespace Wilgnne.Agenda.Domain.Entities;

public class SchoolSubjectSchedule
{
    public Guid Id { get; set; }
    public EWeekDay WeekDay { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public Guid WeekSettingId { get; set; }
    public SchoolSubjectWeekSetting WeekSetting { get; set; } = default!;
}
