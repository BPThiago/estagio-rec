using Microsoft.EntityFrameworkCore;
using EstagioREC.Domain;
using EstagioREC.Persistence.Data;
using EstagioREC.Persistence.Repository.Interfaces;

namespace EstagioREC.Persistence.Repository.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> ObterPorIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> AdicionarAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AtualizarAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeletarAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
