using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskNTeamManganementSystem.Application.Commands;
using TaskNTeamManganementSystem.Application.DTOs;
using TaskNTeamManganementSystem.Application.Queries;

namespace TaskNTeamManganementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }
        [HttpGet("get-user-by-id/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(result);
        }
        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }
            var addUserCommand = new AddUserCommand(
                user.FullName ?? throw new ArgumentException("FullName cannot be null"),
                user.Email ?? throw new ArgumentException("Email cannot be null"),
                user.Role ?? throw new ArgumentException("Role cannot be null")
            );

            var isSuccess = await _mediator.Send(addUserCommand);

            if (!isSuccess)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add user");
            }
            return Ok("User added successfully");
        }
        [HttpPut("update-user/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }
            var updateUserCommand = new UpdateUserCommand(
                id,
                user.FullName ?? throw new ArgumentException("FullName cannot be null"),
                user.Email ?? throw new ArgumentException("Email cannot be null"),
                user.Role ?? throw new ArgumentException("Role cannot be null")
            );
            var isSuccess = await _mediator.Send(updateUserCommand);
            if (!isSuccess)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update user");
            }
            return Ok("User updated successfully");
        }
        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleteUserCommand = new DeleteUserCommand(id);
            var isSuccess = await _mediator.Send(deleteUserCommand);
            if (!isSuccess)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete user");
            }
            return Ok("User deleted successfully");
        }
    }
}
