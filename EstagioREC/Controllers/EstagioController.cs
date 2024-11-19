using EstagioREC.Model;
using EstagioREC.Model.DTOs;
using EstagioREC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EstagioREC.Controllers
{
    [ApiController]
    [Route("/")]
    public class EstagioController : ControllerBase
    {
        private readonly IEstagioRepository _estagioRepository;

        public EstagioController(IEstagioRepository estagioRepository)
        {
            _estagioRepository = estagioRepository;
        }

        [HttpGet("estagios/{id}")]
        public async Task<ActionResult<Estagio>> ObterEstagio(int id)
        {
            var estagio = await _estagioRepository.ObterPorIdAsync(id);
            if (estagio == null)
                return NotFound();
            return estagio;
        }

        [HttpGet("estagios/")]
        public async Task<ActionResult<IEnumerable<Estagio>>> ListarEstagios() 
        {
            return Ok(await _estagioRepository.ObterTodosAsync());
        }

        [HttpPost("estagios/")]
        public async Task<ActionResult<Estagio>> CriarEstagio(EstagioDTO estagioDTO)
        {
            var estagio = new Estagio(estagioDTO);

            await _estagioRepository.AdicionarAsync(estagio);
            return CreatedAtAction(nameof(ObterEstagio), new { id = estagio.Id}, estagio);
        }

        [HttpPut("estagios/{id}")]
        public async Task<IActionResult> AtualizarEstagio(int id, EstagioDTO estagioDTO)
        {
            var estagio = await _estagioRepository.ObterPorIdAsync(id);
            if (estagio == null) return NotFound();
            
            estagio.DatIni = estagioDTO.DatIni;
            estagio.DatFim = estagioDTO.DatFim;
            estagio.Situacao = estagioDTO.Situacao;
            estagio.Aluno = new Aluno(estagioDTO.Aluno);
            estagio.Orientador = new Orientador(estagioDTO.Orientador);
            estagio.Empresa = new Empresa(estagioDTO.Empresa);

            await _estagioRepository.AtualizarAsync(estagio);
            return NoContent();
        }

        [HttpDelete("estagios/{id}")]
        public async Task<IActionResult> DeletarEstagio(int id) 
        {
            var estagio = await _estagioRepository.ObterPorIdAsync(id);
            if (estagio == null)
                return NotFound();
            
            await _estagioRepository.DeletarAsync(id);
            return NoContent();
        }
    }
}
