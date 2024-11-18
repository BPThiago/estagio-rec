using EstagioREC.Model;
using EstagioREC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EstagioREC.Controller
{
    [ApiController]
    [Route("/")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet("alunos/{id}")]
        public async Task<ActionResult<Aluno>> ObterAluno(int id)
        {
            var aluno = await _alunoRepository.ObterPorIdAsync(id);
            if (aluno == null)
                return NotFound();
            return aluno;
        }

        [HttpGet("alunos/")]
        public async Task<ActionResult<IEnumerable<Aluno>>> ListarAlunos() 
        {
            return Ok(await _alunoRepository.ObterTodosAsync());
        }

        [HttpPost("alunos/")]
        public async Task<ActionResult<Aluno>> CriarAluno(AlunoDTO alunoDTO)
        {
            var aluno = new Aluno
            {
                Nome = alunoDTO.Nome,
                Matricula = alunoDTO.Matricula,

            };

            await _alunoRepository.AdicionarAsync(aluno);
            return CreatedAtAction(nameof(ObterAluno), new { id = aluno.Id}, aluno);
        }
    }
}
