using MediatR;
using Wilgnne.Agenda.Domain.Entities;
using Wilgnne.Agenda.Infra.Persistence.Repositories;

namespace Wilgnne.Agenda.Application.Auth.Queries.ApplicationUserFromFirebaseUserIdQuery;

public class ApplicationUserFromFirebaseUserIdQueryHandle : IRequestHandler<ApplicationUserFromFirebaseUserIdQuery, ApplicationUserFromFirebaseUserIdQueryResponse>
{
    private readonly IRepository<ApplicationUser> _repository;

    public ApplicationUserFromFirebaseUserIdQueryHandle(IRepository<ApplicationUser> repository)
    {
        _repository = repository;
    }

    public async Task<ApplicationUserFromFirebaseUserIdQueryResponse> Handle(ApplicationUserFromFirebaseUserIdQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAll((user) => user.FirebaseUserId.Equals(request.FirebaseUserId));
        var user = users.First();

        return new(user);
    }
}
