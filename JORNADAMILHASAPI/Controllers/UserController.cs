using AutoMapper;
using JORNADAMILHASAPI.Data;
using JORNADAMILHASAPI.Data.Dtos;
using JORNADAMILHASAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace JORNADAMILHASAPI.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        
        public IMapper _mapper;
        public UserContext _context { get; set; }

        public UserController(IMapper mapper, UserContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarUser([FromBody] CreateUserDto UserDto) 
        {
            User user = _mapper.Map<User>(UserDto);
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarUsersPorId), new { Id = user.Id }, UserDto);
        }

        [HttpGet]
        public IEnumerable<ReadUserDto> RecuperarUsers()
        {
            return _mapper.Map<List<ReadUserDto>>(_context.Users.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarUsersPorId(int id) 
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null )
            {
                ReadUserDto userdto = _mapper.Map<ReadUserDto>(user);
                return Ok(userdto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUser(int id, [FromBody] UpdateUserDto dto)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, user);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUser(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
