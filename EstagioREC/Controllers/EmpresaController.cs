using EstagioREC.Model;
using EstagioREC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EstagioREC.Controller
{
    
    [ApiController]
    [Route("/")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepository _EmpresaRepository;

        public EmpresaController(IEmpresaRepository EmpresaRepository)
        {
            _EmpresaRepository = EmpresaRepository;
        }

        [HttpGet("Empresas/{id}")]
        public async Task<ActionResult<Empresa>> ObterEmpresa(int id)
        {
            var empresa = await _EmpresaRepository.ObterPorIdAsync(id);
            if (empresa == null)
                return NotFound();
            return empresa;
        }

        [HttpGet("Empresas/")]
        public async Task<ActionResult<IEnumerable<Empresa>>> ListarEmpresaes() 
        {
            return Ok(await _EmpresaRepository.ObterTodosAsync());
        }

        [HttpPost("Empresas/")]
        public async Task<ActionResult<Empresa>> CriarEmpresa(EmpresaDTO empresaDTO)
        {
            var empresa = new Empresa
            {
                nome = empresaDTO.Nome,
                id = empresaDTO.id,
                estagios = empresaDTO.estagios   
            };

            await _EmpresaRepository.AdicionarAsync(empresa);
            return CreatedAtAction(nameof(ObterEmpresa), new { id = empresa.id}, empresa);
        }

                [HttpPut("Empresas/{id}")]
        public async Task<IActionResult> AtualizarEmpresa(int id, EmpresaDTO empresaDto) 
        {
            var empresa = await _EmpresaRepository.ObterPorIdAsync(id);
            if (empresa == null)
                return NotFound();
            
            empresa.nome = empresaDto.Nome;
            empresa.id = empresaDto.id;
            empresa.estagios = empresaDto.estagios;

            await _EmpresaRepository.AtualizarAsync(empresa);
            return NoContent();
        }

        [HttpDelete("Empresas/{id}")]
        public async Task<IActionResult> DeletarEmpresa(int id) 
        {
            var empresa = await _EmpresaRepository.ObterPorIdAsync(id);
            if (empresa == null)
                return NotFound();
            
            await _EmpresaRepository.DeletarAsync(id);
            return NoContent();
        }
    }
}