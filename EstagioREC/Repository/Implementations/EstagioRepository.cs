using EstagioREC.Data;
using EstagioREC.Model;
using EstagioREC.Model.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EstagioREC.Repository.Implementations
{
    public class EstagioRepository : IEstagioRepository
    {
        private readonly AppDbContext _context;

        public EstagioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EstagioResponseDTO> ObterPorIdAsync(int id)
        {
            return await _context.Estagios
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
                .FirstOrDefaultAsync(e => e.Id == id);
        }


        public async Task<IEnumerable<EstagioResponseDTO>> ObterTodosAsync()
        {
            return await _context.Estagios
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


        public async Task<EstagioResponseDTO> AdicionarAsync(Estagio estagio)
        {
            if (estagio == null)
                throw new ArgumentNullException(nameof(estagio));

            try
            {
                _context.Estagios.Add(estagio);
                await _context.SaveChangesAsync();
                return await ObterPorIdAsync(estagio.Id);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar estágio", e);
            }
        }


        public async Task AtualizarAsync(Estagio estagio)
        {
            if (estagio == null)
                throw new ArgumentNullException(nameof(estagio));

            _context.Entry(estagio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var estagio = await _context.Estagios.FindAsync(id);
            _context.Estagios.Remove(estagio);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EstagioResponseDTO>> ObterPorOrientadorAsync(int orientadorId) {
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
    }
}
