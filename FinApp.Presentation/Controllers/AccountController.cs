using FinApp.Application.Commands.CreateAccount;
using FinApp.Application.Dtos;
using FinApp.Application.Queries.GetUserById;
using FinApp.Application.Queries.GetUserByUid;
using FinApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading;

namespace FinApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-account")]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] AccountDto accountDto, CancellationToken cancellationToken)
        {
            if (accountDto == null)
            {
                return BadRequest("Account cannot be null.");
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("sub");
            if(userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }

            var uid = userIdClaim.Value;

            var getUserByUidCommand = new GetUserByUidQuery(uid);
            var userId = await _mediator.Send(getUserByUidCommand, cancellationToken);

            accountDto.UserId = userId;


            var command = new CreateAccountCommand(accountDto);
            var res = await _mediator.Send(command, cancellationToken);
            return Ok(res);
        }
    }
}
