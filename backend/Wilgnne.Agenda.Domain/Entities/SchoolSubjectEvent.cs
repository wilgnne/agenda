namespace Wilgnne.Agenda.Domain.Entities;

public class SchoolSubjectEvent
{
    public Guid Id;
    public string Event = string.Empty;

    public DateTime StartEventDateTime;
    public DateTime EndEventDateTime;

    public Guid SchoolSubjectId;

    public SchoolSubject Subject = default!;
}
