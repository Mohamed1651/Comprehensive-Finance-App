using AutoMapper;
using FinApp.Application.Commands.CreateUser;
using FinApp.Application.Dtos;
using FinApp.Application.Queries.GetUserById;
using FinApp.Application.Queries.GetUsers;
using FinApp.Domain.Entities;
using FinApp.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading;

namespace FinApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("claims")]
        [Authorize]
        public ActionResult GetClaims()
        {
            var claims = HttpContext.User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            return Ok(claims);
        }

        [HttpGet("me")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<UserDto>> GetCurrentUser(CancellationToken cancellationToken)
        {
            var Uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var Name = User.FindFirst("name")?.Value;
            var Email = User.FindFirst("preferred_username")?.Value;
            var dto = new UserDto(0, Uid, Name, Email);
            var command = new CreateUserCommand(dto);
            var loggedInUser = await _mediator.Send(command, cancellationToken);

            return Ok(loggedInUser);
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDto>> Get(CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();
            var userDtos = await _mediator.Send(query, cancellationToken);
            return Ok(userDtos);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDto>> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery(id);
            var userDto = await _mediator.Send(query, cancellationToken);
            return Ok(userDto);
        }
    }
}
