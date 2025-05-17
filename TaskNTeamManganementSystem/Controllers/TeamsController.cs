using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskNTeamManganementSystem.Application.DTOs;
using TaskNTeamManganementSystem.Application.Queries.Teams;

namespace TaskNTeamManganementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-all-teams")]
        public async Task<IActionResult> GetAllTeams()
        {
            var result = await _mediator.Send(new GetAllTeamsQuery());
            return Ok(result);
        }
        //[HttpGet("get-team-by-id/{id}")]
        //public async Task<IActionResult> GetTeamById(int id)
        //{
        //    var result = await _mediator.Send(new GetTeamByIdQuery(id));
        //    return Ok(result);
        //}
        //[HttpPost("add-team")]
        //public async Task<IActionResult> AddTeam([FromBody] TeamsDTO team)
        //{
        //    if (team == null)
        //    {
        //        return BadRequest("Team cannot be null");
        //    }
        //    var addTeamCommand = new AddTeamCommand(
        //        team.Name ?? throw new ArgumentException("Name cannot be null"),
        //        team.Description ?? throw new ArgumentException("Description cannot be null")
        //    );
        //    var isSuccess = await _mediator.Send(addTeamCommand);
        //    if (!isSuccess)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add team");
        //    }
        //    return Ok("Team added successfully");
        //}
        //[HttpPut("update-team/{id}")]
        //public async Task<IActionResult> UpdateTeam(int id, [FromBody] TeamsDTO team)
        //{
        //    if (team == null)
        //    {
        //        return BadRequest("Team cannot be null");
        //    }
        //    var updateTeamCommand = new UpdateTeamCommand(
        //        id,
        //        team.Name ?? throw new ArgumentException("Name cannot be null"),
        //        team.Description ?? throw new ArgumentException("Description cannot be null")
        //    );
        //    var isSuccess = await _mediator.Send(updateTeamCommand);
        //    if (!isSuccess)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update team");
        //    }
        //    return Ok("Team updated successfully");
        //}
        //[HttpDelete("delete-team/{id}")]
        //public async Task<IActionResult> DeleteTeam(int id)
        //{
        //    var deleteTeamCommand = new DeleteTeamCommand(id);
        //    var isSuccess = await _mediator.Send(deleteTeamCommand);
        //    if (!isSuccess)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete team");
        //    }
        //    return Ok();
        //}
    }
}
