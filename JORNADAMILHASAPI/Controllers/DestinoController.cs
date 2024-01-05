using AutoMapper;
using JORNADAMILHASAPI.Data;
using JORNADAMILHASAPI.Data.Dtos;
using JORNADAMILHASAPI.Migrations;
using JORNADAMILHASAPI.Models;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace JORNADAMILHASAPI.Controllers
{
    [ApiController]
    [Route("destinos")]
    public class DestinoController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        public DestinoContext _context { get; set; }

        public DestinoController(IMapper mapper, DestinoContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaDestino([FromBody] CreateDestinoDto DestinoDto)
        {
            var api = new OpenAIAPI("sua key de acesso a API da OpenAI");
            Destino destino = _mapper.Map<Destino>(DestinoDto);
            var result = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                Temperature = 0.1,
                MaxTokens = 115,
                Messages = new ChatMessage[] {
            new ChatMessage(ChatMessageRole.User, $"Faça uma breve descrição sobre {destino.Name}, você tem exatos 100 tokens")
        }
            });

            
           
            

            if (destino.Description == null || destino.Description == "")
            {
                destino.Description = result.ToString();
            }
            _context.Destinos.Add(destino);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarDestinosPorId), new { Id = destino.Id }, DestinoDto);
        }

        [HttpGet]
        public IEnumerable<ReadDestinoDto> RecuperarDestinos()
        {
            return _mapper.Map<List<ReadDestinoDto>>(_context.Destinos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarDestinosPorId(int id)
        {
            Destino destino = _context.Destinos.FirstOrDefault(u => u.Id == id);
            if (destino != null)
            {
                ReadDestinoDto destinodto = _mapper.Map<ReadDestinoDto>(destino);
                return Ok(destino);
            }
            return NotFound("Nenhum destino foi encontrado :(");
        }

        [HttpGet("buscar")]
        public IActionResult BuscarDestinosPorNome([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("O parâmetro 'nome' não pode estar em branco.");
            }

            var destinosEncontrados = _context.Destinos
                .Where(d => d.Name.ToLower().Contains(name.ToLower()))
                .ToList();
            
            if (destinosEncontrados.Count > 0)
            {
                var destinosdto = _mapper.Map<List<ReadDestinoDto>>(destinosEncontrados);
                return Ok(destinosdto);
            }
            return NotFound("Nenhum destino foi encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarDestino(int id, [FromBody] UpdateDestinoDto dto)
        {
            Destino destino = _context.Destinos.FirstOrDefault(u => u.Id == id);
            if (destino == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, destino);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarDestino(int id)
        {
            Destino destino = _context.Destinos.FirstOrDefault(u => u.Id == id);
            if (destino == null)
            {
                return NotFound();
            }
            _context.Destinos.Remove(destino);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
