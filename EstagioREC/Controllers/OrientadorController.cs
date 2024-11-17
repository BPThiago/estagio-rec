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
    }
}