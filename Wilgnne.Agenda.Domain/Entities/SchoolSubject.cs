namespace Wilgnne.Agenda.Domain.Entities
{
    public class SchoolSubject(string subject)
    {
        public Guid Id { get; set; }
        public string Subject { get; set; } = subject;
    }
}
