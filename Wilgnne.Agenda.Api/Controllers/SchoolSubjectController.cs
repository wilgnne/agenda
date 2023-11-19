using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wilgnne.Agenda.Application.SchoolSubjects.Command.InsertSchoolSubjectCommand;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wilgnne.Agenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolSubjectController(IMediator mediator) : ControllerBase
    {

        // POST api/<SchoolSubjectController>
        [HttpPost]
        public async Task<InsertSchoolSubjectCommandResponse> Post([FromBody] InsertSchoolSubjectCommand body)
        {
            return await mediator.Send(body);
        }
    }
}
