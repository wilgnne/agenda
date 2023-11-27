using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wilgnne.Agenda.Application.Dtos;
using Wilgnne.Agenda.Application.SchoolSubjects.Command.EditSchoolSubjectCommand;
using Wilgnne.Agenda.Application.SchoolSubjects.Command.InsertSchoolSubjectCommand;
using Wilgnne.Agenda.Application.SchoolSubjects.Queries.AllSchoolSubjectQuery;

namespace Wilgnne.Agenda.Api.Controllers;

[Route("api/school-subject")]
[ApiController]
public class SchoolSubjectController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<AllSchoolSubjectQueryResponse>> GetAll([FromQuery] AllSchoolSubjectQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpPost]
    [ProducesResponseType<InsertSchoolSubjectCommandResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize]
    public async Task<ActionResult> Post([FromBody] SubjectDto body)
    {
        var user = await this.GetApplicationUser(mediator);

        return Ok(await mediator.Send(new InsertSchoolSubjectCommand(user.Id, body.Subject)));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Put(string id, [FromBody] SubjectDto body)
    {
        var user = await this.GetApplicationUser(mediator);
        await mediator.Send(new EditSchoolSubjectCommand(user.Id, Guid.Parse(id), body.Subject));

        return Ok();
    }
}
