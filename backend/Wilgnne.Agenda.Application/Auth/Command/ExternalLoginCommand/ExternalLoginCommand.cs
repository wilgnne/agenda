using MediatR;

namespace Wilgnne.Agenda.Application.Auth.Command.ExternalLoginCommand;

public record ExternalLoginCommand(string FirebaseUserId, string Email) : IRequest<ExternalLoginCommandResponse>;