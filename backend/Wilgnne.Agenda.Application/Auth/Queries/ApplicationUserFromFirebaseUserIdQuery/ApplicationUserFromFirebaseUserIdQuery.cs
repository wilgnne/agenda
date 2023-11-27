using MediatR;

namespace Wilgnne.Agenda.Application.Auth.Queries.ApplicationUserFromFirebaseUserIdQuery;

public record ApplicationUserFromFirebaseUserIdQuery(string FirebaseUserId) : IRequest<ApplicationUserFromFirebaseUserIdQueryResponse>;
