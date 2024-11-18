using Microsoft.EntityFrameworkCore;
using EstagioREC.Model;
using EstagioREC.Data;

namespace EstagioREC.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly EstagioDb _context;

        public AlunoRepository(EstagioDb context) {
            _context = context;
        }

        public async Task<Aluno> ObterPorIdAsync(int id) {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task<IEnumerable<Aluno>> ObterTodosAsync() {
            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno> AdicionarAsync(Aluno aluno) {
            if (aluno == null)
                throw new ArgumentNullException(nameof(aluno));
            
            try 
            {
                _context.Alunos.Add(aluno);
                await _context.SaveChangesAsync();
                return aluno;
            } catch (Exception e) 
            {
                throw new Exception("Erro ao adicionar aluno", e);    
            }
        }
    }
}

