using EstagioREC.Model;

namespace EstagioREC.Repository
{
    public interface IEmpresaRepository
    {
        Task<Empresa> ObterPorIdAsync(int id);
        Task<IEnumerable<Empresa>> ObterTodosAsync();
        Task<Empresa> AdicionarAsync(Empresa empresa);
        Task AtualizarAsync(Empresa empresa);
        Task DeletarAsync(int id);
    }
}
