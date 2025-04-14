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
/*        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            return await _userService.Get(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task Post([FromBody] UserDto value)
        {
            await _userService.Post(value);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDto value)
        {
            _userService.Put(value);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }*/
    }
}
