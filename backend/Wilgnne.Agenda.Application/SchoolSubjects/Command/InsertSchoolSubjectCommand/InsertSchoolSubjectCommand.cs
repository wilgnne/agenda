using MediatR;

namespace Wilgnne.Agenda.Application.SchoolSubjects.Command.InsertSchoolSubjectCommand
{
    public record InsertSchoolSubjectCommand(string Subject) : IRequest<InsertSchoolSubjectCommandResponse>;
}
