using EstagioREC.Model;
using EstagioREC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EstagioREC.Controller 
{
    [ApiController]
    [Route("/")]
    public class OrientadorController : ControllerBase
    {
        private readonly IOrientadorRepository _orientadorRepository;

        public OrientadorController(IOrientadorRepository orientadorRepository)
        {
            _orientadorRepository = orientadorRepository;
        }

        [HttpGet("orientadores/{id}")]
        public async Task<ActionResult<Orientador>> ObterOrientador(int id)
        {
            var orientador = await _orientadorRepository.ObterPorIdAsync(id);
            if (orientador == null)
                return NotFound();
            return orientador;
        }

        [HttpGet("orientadores/")]
        public async Task<ActionResult<IEnumerable<Orientador>>> ListarOrientadores() 
        {
            return Ok(await _orientadorRepository.ObterTodosAsync());
        }

        [HttpPost("orientadores/")]
        public async Task<ActionResult<Orientador>> CriarOrientador(OrientadorDTO orientadorDTO)
        {
            var orientador = new Orientador
            {
                Nome = orientadorDTO.Nome,
                Email = orientadorDTO.Email,
                Telefone = orientadorDTO.Telefone    
            };

            await _orientadorRepository.AdicionarAsync(orientador);
            return CreatedAtAction(nameof(ObterOrientador), new { id = orientador.Id}, orientador);
        }

                [HttpPut("orientadores/{id}")]
        public async Task<IActionResult> AtualizarOrientador(int id, OrientadorDTO orientadorDTO) 
        {
            var orientador = await _orientadorRepository.ObterPorIdAsync(id);
            if (orientador == null)
                return NotFound();
            
            orientador.Nome = orientadorDTO.Nome;
            orientador.Email = orientadorDTO.Email;
            orientador.Telefone = orientadorDTO.Telefone;

            await _orientadorRepository.AtualizarAsync(orientador);
            return NoContent();
        }

        [HttpDelete("orientadores/{id}")]
        public async Task<IActionResult> DeletarOrientador(int id) 
        {
            var orientador = await _orientadorRepository.ObterPorIdAsync(id);
            if (orientador == null)
                return NotFound();
            
            await _orientadorRepository.DeletarAsync(id);
            return NoContent();
        }
    }
}