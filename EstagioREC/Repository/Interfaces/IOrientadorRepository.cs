using EstagioREC.Model;

namespace EstagioREC.Repository 
{
    public interface IOrientadorRepository
    {
        Task<Orientador> ObterPorIdAsync(int id);
        Task<IEnumerable<Orientador>> ObterTodosAsync();
        Task<Orientador> AdicionarAsync(Orientador orientador);
        Task AtualizarAsync(Orientador orientador);
        Task DeletarAsync(int id);
    }
}