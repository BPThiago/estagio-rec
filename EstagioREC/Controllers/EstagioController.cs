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
        public async Task<ActionResult<EstagioResponseDTO>> ObterEstagio(int id)
        {
            var estagio = await _estagioRepository.ObterPorIdAsync(id);
            if (estagio == null)
                return NotFound();

            return Ok(estagio);
        }

        [HttpGet("estagios/")]
        public async Task<ActionResult<IEnumerable<EstagioResponseDTO>>> ListarEstagios()
        {
            return Ok(await _estagioRepository.ObterTodosAsync());
        }

        [HttpPost("estagios/")]
        public async Task<ActionResult<EstagioResponseDTO>> CriarEstagio(EstagioDTO estagioDTO)
        {
            // Mapear o DTO para a entidade
            var estagio = new Estagio
            {
                DatIni = estagioDTO.DatIni,
                DatFim = estagioDTO.DatFim,
                Situacao = estagioDTO.Situacao,
                AlunoId = estagioDTO.AlunoId,
                OrientadorId = estagioDTO.OrientadorId,
                EmpresaId = estagioDTO.EmpresaId
            };

            var estagioCriado = await _estagioRepository.AdicionarAsync(estagio);

            return CreatedAtAction(nameof(ObterEstagio), new { id = estagioCriado.Id }, estagioCriado);
        }

        [HttpPut("estagios/{id}")]
        public async Task<IActionResult> AtualizarEstagio(int id, EstagioDTO estagioDTO)
        {
            var estagioExistente = await _estagioRepository.ObterPorIdAsync(id);
            if (estagioExistente == null)
                return NotFound();

            // Mapear os valores do DTO para a entidade
            var estagio = new Estagio
            {
                Id = id,
                DatIni = estagioDTO.DatIni,
                DatFim = estagioDTO.DatFim,
                Situacao = estagioDTO.Situacao,
                AlunoId = estagioDTO.AlunoId,
                OrientadorId = estagioDTO.OrientadorId,
                EmpresaId = estagioDTO.EmpresaId
            };

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

        [HttpGet("estagios/orientador/{orientadorId}")]
        public async Task<ActionResult<IEnumerable<EstagioResponseDTO>>> ListarEstagiosPorOrientador(int orientadorId) {
            var estagios = await _estagioRepository.ObterPorOrientadorAsync(orientadorId);
            return Ok(estagios);
        }
    }
}
