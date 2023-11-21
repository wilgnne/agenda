using MediatR;

namespace Wilgnne.Agenda.Application.SchoolSubjects.Queries.AllSchoolSubjectQuery;

public record AllSchoolSubjectQuery : IRequest<IEnumerable<AllSchoolSubjectQueryResponse>>;
