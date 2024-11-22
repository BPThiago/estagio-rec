using EstagioREC.Model;
using EstagioREC.Model.DTOs;

namespace EstagioREC.Repository
{
    public interface IEstagioRepository
    {
        Task<EstagioResponseDTO> ObterPorIdAsync(int id);
        Task<IEnumerable<EstagioResponseDTO>> ObterTodosAsync();
        Task<EstagioResponseDTO> AdicionarAsync(Estagio estagio);
        Task AtualizarAsync(Estagio estagio);
        Task DeletarAsync(int id);
    }
}
