using EstagioREC.Domain;

namespace EstagioREC.Persistence.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> ObterPorIdAsync(int id);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<T> AdicionarAsync(T entity);
        Task AtualizarAsync(T entity);
        Task DeletarAsync(T entity);
    }
}
