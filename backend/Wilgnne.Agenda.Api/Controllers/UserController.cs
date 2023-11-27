using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Wilgnne.Agenda.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController() : ControllerBase
{
    // POST api/<UserController>
    [HttpGet]
    [Authorize]
    public dynamic Get()
    {
        return new
        {
            types = User.Claims.ToList().Select(x => x.Type),
            user_id = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value,
            firebase = User.Claims.FirstOrDefault(x => x.Type == "firebase")?.Value,
            email_verified = User.Claims.FirstOrDefault(x => x.Type == "email_verified")?.Value,
            name = User.Claims.FirstOrDefault(x => x.Type == "name")?.Value,
            emailaddress = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value,
        };
    }
}
