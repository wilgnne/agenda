using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wilgnne.Agenda.Application.Auth.Queries.ApplicationUserFromFirebaseUserIdQuery;
using Wilgnne.Agenda.Domain.Entities;

namespace Wilgnne.Agenda.Api;

public static partial class ApplicationUserControllerBase
{
    public static async Task<ApplicationUser> GetApplicationUser(this ControllerBase controller, IMediator mediator)
    {
        var firebaseUserId = controller.User.Claims.First(x => x.Type == "user_id").Value;

        var response = await mediator.Send(new ApplicationUserFromFirebaseUserIdQuery(firebaseUserId));

        return response.User;
    }
}
