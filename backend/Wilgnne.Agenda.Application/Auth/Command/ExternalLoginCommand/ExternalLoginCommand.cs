using MediatR;

namespace Wilgnne.Agenda.Application;

public record ExternalLoginCommand(string FirebaseUserId, string Email) : IRequest<ExternalLoginCommandResponse>;