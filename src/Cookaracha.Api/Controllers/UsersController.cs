using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Commands;
using Cookaracha.Application.DTO;
using Cookaracha.Infrastructure.DAL.Queries;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Cookaracha.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    [SwaggerOperation("Get all users.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get(
        [FromQuery] GetUsers query,
        [FromServices] IQueryHandler<GetUsers, IEnumerable<UserDto>> handler)
        => Ok(await handler.HandleAsync(query));

    [HttpGet("{id:guid}")]
    [SwaggerOperation("Get user by ID.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<UserDto>> Get(
        [FromRoute] Guid id,
        [FromServices] IQueryHandler<GetUser, UserDto> handler)
        => Ok(await handler.HandleAsync(new(id)));

    [HttpPost]
    [SwaggerOperation("Create new user account.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(
        [FromBody] SignUp command,
        [FromServices] ICommandHandler<SignUp> handler)
    {
        command = command with { Id = Guid.NewGuid() };
        await handler.HandleAsync(command);
        return CreatedAtAction(nameof(Get), new { command.Id }, null);
    }
}