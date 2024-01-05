using AutoMapper;
using JORNADAMILHASAPI.Data;
using JORNADAMILHASAPI.Data.Dtos;
using JORNADAMILHASAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace JORNADAMILHASAPI.Controllers
{
    [ApiController]
    [Route("depoimentos-home")]
    public class DepoimentosHomeController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        public UserContext _context { get; set; }
        public DepoimentosHomeController(IMapper mapper, UserContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDepoimentosHome()
        {
            Random random = new Random();
            List<int> idsAleatorios = new List<int>();

            while (idsAleatorios.Count < 3)
            {
                int randomId = random.Next(1, _context.Users.Count() + 1); 
                if (!idsAleatorios.Contains(randomId))
                {
                    idsAleatorios.Add(randomId);
                }
            }

            List<User> depoimentos = _context.Users
                .Where(u => idsAleatorios.Contains(u.Id))
                .ToList();

            List<ReadUserDto> depoimentosDto = _mapper.Map<List<ReadUserDto>>(depoimentos);

            if (depoimentosDto.Count == 0)
            {
                return NotFound("Nenhum depoimento encontrado");
            }

            return Ok(depoimentosDto);
        }
    }
}
