namespace Wilgnne.Agenda.Domain.Entities
{
    public class SchoolSubject(Guid UserId, string subject)
    {
        public Guid Id { get; set; }
        public string Subject { get; set; } = subject;

        public Guid UserId { get; set; } = UserId;
        public ApplicationUser User { get; set; } = default!;

        public ICollection<SchoolSubjectEvent> SubjectEvents { get; set; } = default!;
        public ICollection<SchoolSubjectWeekSetting> WeekSettings { get; set; } = default!;
    }
}
