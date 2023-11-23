using MediatR;

namespace Wilgnne.Agenda.Application.SchoolSubjectEvents.Command.InsertSchoolSubjectEventCommand;

public record InsertSchoolSubjectEventCommand(
    string Event,
    DateTime StartEventDateTime,
    DateTime EndEventDateTime,
    Guid SchoolSubjectId
) : IRequest<Guid>;
