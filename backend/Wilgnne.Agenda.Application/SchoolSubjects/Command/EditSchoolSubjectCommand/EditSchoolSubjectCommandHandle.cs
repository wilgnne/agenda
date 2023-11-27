using MediatR;
using Wilgnne.Agenda.Domain.Entities;
using Wilgnne.Agenda.Infra.Persistence.Repositories;

namespace Wilgnne.Agenda.Application.SchoolSubjects.Command.EditSchoolSubjectCommand;

public class EditSchoolSubjectCommandHandle : IRequestHandler<EditSchoolSubjectCommand>
{
    private readonly IRepository<SchoolSubject> _repository;

    public EditSchoolSubjectCommandHandle(IRepository<SchoolSubject> repository)
    {
        _repository = repository;
    }

    public async Task Handle(EditSchoolSubjectCommand request, CancellationToken cancellationToken)
    {
        await _repository.Edit(request.SchoolSubjectId, new { request.Subject });
    }
}
