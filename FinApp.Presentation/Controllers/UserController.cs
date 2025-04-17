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
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<UserDto>> Get()
        {
            IEnumerable<User> user = await _userService.GetUsers();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(user);
            return Ok(userDtos);
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            User user = await _userService.GetUser(id);
            UserDto userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto dto)
        {
            User user = _mapper.Map<User>(dto);
            await _userService.CreateUser(user);
            return Created();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto dto)
        {
            User userToUpdate = _mapper.Map<User>(dto);
            userToUpdate.Id = id;

            await _userService.UpdateUser(userToUpdate);

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
