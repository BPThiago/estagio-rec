using Microsoft.EntityFrameworkCore;
using EstagioREC.Model;
using EstagioREC.Data;

namespace EstagioREC.Repository 
{
    public class OrientadorRepository : IOrientadorRepository
    {
        private readonly EstagioDb _context;

        public OrientadorRepository(EstagioDb context) {
            _context = context;
        }

        public async Task<Orientador> ObterPorIdAsync(int id) {
            return await _context.Orientadores.FindAsync(id);
        }

        public async Task<IEnumerable<Orientador>> ObterTodosAsync() {
            return await _context.Orientadores.ToListAsync();
        }

        public async Task<Orientador> AdicionarAsync(Orientador orientador) {
            if (orientador == null)
                throw new ArgumentNullException(nameof(orientador));
            
            try 
            {
                _context.Orientadores.Add(orientador);
                await _context.SaveChangesAsync();
                return orientador;
            } catch (Exception e) 
            {
                throw new Exception("Erro ao adicionar orientador", e);    
            }
        }
    }
}