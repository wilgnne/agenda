namespace Wilgnne.Agenda.Domain.Entities;

public class SchoolSubjectWeekSetting
{
    public Guid Id { get; set; }
    public int Order { get; set; }

    public Guid SchoolSubjectId { get; set; }
    public SchoolSubject SchoolSubject { get; set; } = default!;
    public ICollection<SchoolSubjectSchedule> SubjectSchedules { get; set; } = default!;
}
