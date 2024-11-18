using EstagioREC.Model;

namespace EstagioREC.Repository
{
    public interface IAlunoRepository
    {
        Task<Aluno> ObterPorIdAsync(int id);
        Task<IEnumerable<Aluno>> ObterTodosAsync();
        Task<Aluno> AdicionarAsync(Aluno aluno);
    }
}

