namespace Wilgnne.Agenda.Domain.Entities;

public class ApplicationUser(string firebaseUserId, string email)
{
    public Guid Id;
    public string FirebaseUserId { get; set; } = firebaseUserId;
    public string Email { get; set; } = email;

    public ICollection<SchoolSubject> SchoolSubjects { get; set; } = default!;
}
