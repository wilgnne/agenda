using MediatR;
using Wilgnne.Agenda.Domain.Entities;
using Wilgnne.Agenda.Infra.Persistence.Repositories;

namespace Wilgnne.Agenda.Application.SchoolSubjectEvents.Command.InsertSchoolSubjectEventCommand;

public class InsertSchoolSubjectEventCommandHandle : IRequestHandler<InsertSchoolSubjectEventCommand, Guid>
{
    private readonly IRepository<SchoolSubjectEvent> _repository;

    public InsertSchoolSubjectEventCommandHandle(IRepository<SchoolSubjectEvent> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(InsertSchoolSubjectEventCommand request, CancellationToken cancellationToken)
    {
        var schoolSubjectEvent = await _repository.Insert(new SchoolSubjectEvent
        {
            Event = request.Event,
            StartEventDateTime = request.StartEventDateTime,
            EndEventDateTime = request.EndEventDateTime,
            SchoolSubjectId = request.SchoolSubjectId
        });

        return schoolSubjectEvent.Id;
    }
}
