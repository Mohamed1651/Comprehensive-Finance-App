using AutoMapper;
using FinApp.Application.Interfaces;
using FinApp.Domain.Entities;
using FinApp.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericService<User> _userService;
        private readonly IMapper _mapper;

        public UserController(IGenericService<User> userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<UserDto>> Get()
        {
            IEnumerable<User> user = await _userService.Get();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(user);
            return Ok(userDtos);
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            User user = await _userService.Get(id);
            UserDto userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto value)
        {
            User user = _mapper.Map<User>(value);
            await _userService.Post(user);
            return Created();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto value)
        {
            if (id != value.Id)
            {
                return BadRequest("The user ID in the path and body must match.");
            }
            User userToUpdate = _mapper.Map<User>(value);

            var existingUser = await _userService.Get(id);

            if (existingUser == null)
            {
                return NotFound($"User with ID {id} was not found.");
            }
            await _userService.Put(userToUpdate);

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
    }
}
