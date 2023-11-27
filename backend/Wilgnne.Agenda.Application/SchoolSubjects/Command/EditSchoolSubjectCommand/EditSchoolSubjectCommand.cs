using MediatR;

namespace Wilgnne.Agenda.Application.SchoolSubjects.Command.EditSchoolSubjectCommand;

public record EditSchoolSubjectCommand(Guid UserId, Guid SchoolSubjectId, string Subject) : IRequest;
