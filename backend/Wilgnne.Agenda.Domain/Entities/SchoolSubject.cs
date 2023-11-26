namespace Wilgnne.Agenda.Domain.Entities
{
    public class SchoolSubject(string subject)
    {
        public Guid Id { get; set; }
        public string Subject { get; set; } = subject;

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = default!;

        public ICollection<SchoolSubjectEvent> SubjectEvents { get; set; } = default!;
    }
}
