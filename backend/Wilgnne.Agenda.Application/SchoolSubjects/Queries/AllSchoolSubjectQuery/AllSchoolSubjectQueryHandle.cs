using MediatR;
using Wilgnne.Agenda.Domain.Entities;
using Wilgnne.Agenda.Infra.Persistence.Repositories;

namespace Wilgnne.Agenda.Application.SchoolSubjects.Queries.AllSchoolSubjectQuery;

public class AllSchoolSubjectQueryHandle : IRequestHandler<AllSchoolSubjectQuery, IEnumerable<AllSchoolSubjectQueryResponse>>
{
    private readonly IRepository<SchoolSubject> _repository;

    public AllSchoolSubjectQueryHandle(IRepository<SchoolSubject> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AllSchoolSubjectQueryResponse>> Handle(AllSchoolSubjectQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAll((_) => true);

        return entities.Select((entity) => new AllSchoolSubjectQueryResponse(entity.Id, entity.Subject));
    }
}
