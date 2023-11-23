using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wilgnne.Agenda.Application.SchoolSubjectEvents.Command.InsertSchoolSubjectEventCommand;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wilgnne.Agenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolSubjectEventController(IMediator mediator) : ControllerBase
    {
        // POST api/<SchoolSubjectEventController>
        [HttpPost]
        public async Task<Guid> Post([FromBody] InsertSchoolSubjectEventCommand body)
        {
            return await mediator.Send(body);
        }
    }
}
