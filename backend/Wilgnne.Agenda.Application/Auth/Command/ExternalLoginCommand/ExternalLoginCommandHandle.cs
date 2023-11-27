using MediatR;
using Wilgnne.Agenda.Domain.Entities;
using Wilgnne.Agenda.Infra.Persistence.Repositories;

namespace Wilgnne.Agenda.Application.Auth.Command.ExternalLoginCommand;

public class ExternalLoginCommandHandle : IRequestHandler<ExternalLoginCommand, ExternalLoginCommandResponse>
{
    private readonly IRepository<ApplicationUser> _repository;

    public ExternalLoginCommandHandle(IRepository<ApplicationUser> repository)
    {
        _repository = repository;
    }

    public async Task<ExternalLoginCommandResponse> Handle(ExternalLoginCommand request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAll((user) => user.FirebaseUserId.Equals(request.FirebaseUserId));
        var user = users.FirstOrDefault();

        if (user is not null) return new ExternalLoginCommandResponse(user.Id);

        var newUser = await _repository.Insert(new ApplicationUser(request.FirebaseUserId, request.Email));
        return new ExternalLoginCommandResponse(newUser.Id);
    }
}
