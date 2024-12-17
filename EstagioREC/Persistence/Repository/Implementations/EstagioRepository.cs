using EstagioREC.Domain;
using EstagioREC.Persistence.Data;
using EstagioREC.Persistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstagioREC.Persistence.Repository.Implementations
{
    public class EstagioRepository : BaseRepository<Estagio>, IEstagioRepository
    {
        public EstagioRepository(AppDbContext context) : base(context)
        {
        }

        /*
        public async Task<IEnumerable<EstagioResponseDTO>> ObterPorOrientadorAsync(int orientadorId)
        {
            return await _context.Orientadores
                .Include(o => o.Estagios)
                .Where(o => o.Id == orientadorId)
                .SelectMany(o => o.Estagios)
                .Include(e => e.Aluno)
                .Include(e => e.Orientador)
                .Include(e => e.Empresa)
                .Select(e => new EstagioResponseDTO(
                    e.Id,
                    e.DatIni,
                    e.DatFim,
                    e.Situacao,
                    new AlunoDTO(e.Aluno.Id, e.Aluno.Nome, e.Aluno.Matricula),
                    new OrientadorDTO(e.Orientador.Id, e.Orientador.Nome, e.Orientador.Email, e.Orientador.Telefone),
                    new EmpresaDTO(e.Empresa.Id, e.Empresa.Nome)
                ))
                .ToListAsync();
        }

        public async Task<IEnumerable<EstagioResponseDTO>> ObterPorAlunoAsync(int alunoId)
        {
            return await _context.Alunos
                .Include(a => a.Estagios)
                .Where(a => a.Id == alunoId)
                .SelectMany(a => a.Estagios)
                .Include(e => e.Aluno)
                .Include(e => e.Orientador)
                .Include(e => e.Empresa)
                .Select(e => new EstagioResponseDTO(
                    e.Id,
                    e.DatIni,
                    e.DatFim,
                    e.Situacao,
                    new AlunoDTO(e.Aluno.Id, e.Aluno.Nome, e.Aluno.Matricula),
                    new OrientadorDTO(e.Orientador.Id, e.Orientador.Nome, e.Orientador.Email, e.Orientador.Telefone),
                    new EmpresaDTO(e.Empresa.Id, e.Empresa.Nome)
                ))
                .ToListAsync();
        }

        public async Task<IEnumerable<EstagioResponseDTO>> ObterPorEmpresaAsync(int empresaId)
        {
            return await _context.Empresas
                .Include(e => e.Estagios)
                .Where(e => e.Id == empresaId)
                .SelectMany(e => e.Estagios)
                .Include(e => e.Aluno)
                .Include(e => e.Orientador)
                .Include(e => e.Empresa)
                .Select(e => new EstagioResponseDTO(
                    e.Id,
                    e.DatIni,
                    e.DatFim,
                    e.Situacao,
                    new AlunoDTO(e.Aluno.Id, e.Aluno.Nome, e.Aluno.Matricula),
                    new OrientadorDTO(e.Orientador.Id, e.Orientador.Nome, e.Orientador.Email, e.Orientador.Telefone),
                    new EmpresaDTO(e.Empresa.Id, e.Empresa.Nome)
                ))
                .ToListAsync();
        }
        */
    }
}
