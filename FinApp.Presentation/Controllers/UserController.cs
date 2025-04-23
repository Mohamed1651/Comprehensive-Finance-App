using AutoMapper;
using FinApp.Application.Interfaces;
using FinApp.Domain.Entities;
using FinApp.Presentation.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("me")]
        [Authorize(Roles = "User")]
        public IActionResult GetCurrentUser()
        {
            ClaimsPrincipal user = HttpContext.User;
            return Ok(new
            {
                Name = user.FindFirst(ClaimTypes.Name)?.Value,
                Email = user.FindFirst("preferred_username")?.Value,
                ObjectId = user.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value,
                Roles = user.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList()
            });
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDto>> Get()
        {
            IEnumerable<User> user = await _userService.GetUsers();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(user);
            return Ok(userDtos);
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            User user = await _userService.GetUser(id);
            UserDto userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        // POST api/<UserController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] UserDto dto)
        {
            User user = _mapper.Map<User>(dto);
            await _userService.CreateUser(user);
            return Created();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto dto)
        {
            User userToUpdate = _mapper.Map<User>(dto);
            userToUpdate.Id = id;

            await _userService.UpdateUser(userToUpdate);

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
