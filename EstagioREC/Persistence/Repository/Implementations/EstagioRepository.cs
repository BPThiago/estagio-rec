using EstagioREC.Domain;
using EstagioREC.Persistence.Data;
using EstagioREC.Persistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstagioREC.Persistence.Repository.Implementations
{
    public class EstagioRepository : BaseRepository<Estagio>, IEstagioRepository
    {
        public EstagioRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task <IEnumerable<Estagio>> ObterPorAlunoAsync(int alunoId, CancellationToken cancellationToken)
        {
            return await _context.Set<Estagio>()
                .Where(e => e.AlunoId == alunoId)
                .ToListAsync(cancellationToken);
        }
        public async Task <IEnumerable<Estagio>> ObterPorOrientadorAsync(int orientadorId, CancellationToken cancellationToken)
        {
            return await _context.Set<Estagio>()
                .Where(e => e.OrientadorId == orientadorId)
                .ToListAsync(cancellationToken);
        }

        public async Task <IEnumerable<Estagio>> ObterPorEmpresaAsync(int empresaId, CancellationToken cancellationToken)
        {
            return await _context.Set<Estagio>()
                .Where(e => e.EmpresaId == empresaId)
                .ToListAsync(cancellationToken);
        }

    }
}
