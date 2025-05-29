using System.Security.Claims;
using System.Threading;
using AutoMapper;
using FinApp.Application.Commands.CreateUser;
using FinApp.Application.Dtos;
using FinApp.Application.Interfaces;
using FinApp.Application.Queries.GetUserById;
using FinApp.Application.Queries.GetUsers;
using FinApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserController(IUserService userService, IMapper mapper, IMediator mediator)
        {
            _userService = userService;
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

            var command = new CreateUserCommand();
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

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Put([FromBody] UserDto dto)
        {
            await _userService.UpdateUser(dto);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
