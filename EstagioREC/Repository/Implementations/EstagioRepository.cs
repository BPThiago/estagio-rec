using EstagioREC.Data;
using EstagioREC.Model;
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

        public async Task<Estagio> ObterPorIdAsync(int id)
        {
            return await _context.Estagios.FindAsync(id);
        }
        public async Task<IEnumerable<Estagio>> ObterTodosAsync()
        {
            return await _context.Estagios.ToListAsync();
        }

        public async Task<Estagio> AdicionarAsync(Estagio estagio)
        {
            if (estagio == null)
                throw new ArgumentNullException(nameof(estagio));

            try
            {
                _context.Estagios.Add(estagio);
                await _context.SaveChangesAsync();
                return estagio;
            }  catch (Exception e)
            {
                throw new Exception("Erro ao adicionar estagio", e);
            }
        }

        public async Task AtualizarAsync(Estagio estagio)
        {
            _context.Entry(estagio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var estagio = await _context.Estagios.FindAsync(id);
            if (estagio == null)
                return;

            _context.Estagios.Remove(estagio);
            await _context.SaveChangesAsync();
        }
    }
}
