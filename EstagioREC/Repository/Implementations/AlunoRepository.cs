using Microsoft.EntityFrameworkCore;
using EstagioREC.Model;
using EstagioREC.Data;

namespace EstagioREC.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context) {
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

        public async Task AtualizarAsync(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        
        public async Task DeletarAsync(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return;
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }
        
        
    }
}

