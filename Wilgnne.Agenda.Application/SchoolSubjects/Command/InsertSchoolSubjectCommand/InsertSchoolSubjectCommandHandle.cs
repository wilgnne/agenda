using MediatR;
using Wilgnne.Agenda.Domain.Entities;
using Wilgnne.Agenda.Infra.Persistence.Repositories;

namespace Wilgnne.Agenda.Application.SchoolSubjects.Command.InsertSchoolSubjectCommand
{
    public class InsertSchoolSubjectCommandHandle : IRequestHandler<InsertSchoolSubjectCommand, InsertSchoolSubjectCommandResponse>
    {
        private readonly IRepository<SchoolSubject> _repository;

        public InsertSchoolSubjectCommandHandle(IRepository<SchoolSubject> repository)
        {
            _repository = repository;
        }

        public async Task<InsertSchoolSubjectCommandResponse> Handle(InsertSchoolSubjectCommand request, CancellationToken cancellationToken)
        {
            var schoolSubject = await _repository.Insert(new(request.Subject));

            return new(schoolSubject.Id, schoolSubject.Subject);
        }
    }
}
