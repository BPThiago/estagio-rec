using EstagioREC.Model;

namespace EstagioREC.Repository
{
    public interface IEstagioRepository
    {
        Task<Estagio> ObterPorIdAsync(int id);
        Task<IEnumerable<Estagio>> ObterTodosAsync();
        Task<Estagio> AdicionarAsync(Estagio estagio);
        Task AtualizarAsync(Estagio estagio);
        Task DeletarAsync(int id);
    }
}
