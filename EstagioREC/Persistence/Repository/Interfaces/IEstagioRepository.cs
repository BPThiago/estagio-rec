using EstagioREC.Domain;

namespace EstagioREC.Persistence.Repository.Interfaces
{
    public interface IEstagioRepository : IBaseRepository<Estagio>
    {
        public Task <IEnumerable<Estagio>> ObterPorAlunoAsync(int alunoId, CancellationToken cancellationToken);
        public Task <IEnumerable<Estagio>> ObterPorOrientadorAsync(int orientadorId, CancellationToken cancellationToken);
        public Task <IEnumerable<Estagio>> ObterPorEmpresaAsync(int empresaId, CancellationToken cancellationToken);

    }
}
