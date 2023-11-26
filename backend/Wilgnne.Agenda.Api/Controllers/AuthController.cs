using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wilgnne.Agenda.Application;

namespace Wilgnne.Agenda.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpGet("external-login-callback")]
    [ProducesResponseType<ExternalLoginCommandResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize]
    public async Task<ActionResult> ExternalLoginCallback()
    {
        var firebaseUserId = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        var email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

        if (firebaseUserId is null) return Forbid();
        if (email is null) return Forbid();

        var applicationUser = await mediator.Send(new ExternalLoginCommand(firebaseUserId, email));

        return Ok(applicationUser);
    }
}
