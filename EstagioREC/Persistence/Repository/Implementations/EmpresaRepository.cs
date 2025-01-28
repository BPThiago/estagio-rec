using Microsoft.EntityFrameworkCore;
using EstagioREC.Domain;
using EstagioREC.Persistence.Data;
using EstagioREC.Persistence.Repository.Interfaces;

namespace EstagioREC.Persistence.Repository.Implementations
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(AppDbContext context) : base(context)
        {
        }
    }
}