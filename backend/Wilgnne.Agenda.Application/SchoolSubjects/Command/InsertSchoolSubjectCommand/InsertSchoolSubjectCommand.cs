using MediatR;

namespace Wilgnne.Agenda.Application.SchoolSubjects.Command.InsertSchoolSubjectCommand
{
    public record InsertSchoolSubjectCommand(Guid UserId, string Subject) : IRequest<InsertSchoolSubjectCommandResponse>;
}
