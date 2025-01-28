using EstagioREC.Domain;

namespace EstagioREC.Persistence.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> ObterPorIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> ObterTodosAsync(CancellationToken cancellationToken);
        Task<T> AdicionarAsync(T entity, CancellationToken cancellationToken);
        Task AtualizarAsync(T entity, CancellationToken cancellationToken);
        Task DeletarAsync(T entity, CancellationToken cancellationToken);
    }
}
