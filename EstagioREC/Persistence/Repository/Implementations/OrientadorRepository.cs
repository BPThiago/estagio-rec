using Microsoft.EntityFrameworkCore;
using EstagioREC.Domain;
using EstagioREC.Persistence.Data;
using EstagioREC.Persistence.Repository.Interfaces;

namespace EstagioREC.Persistence.Repository.Implementations
{
    public class OrientadorRepository : BaseRepository<Orientador>, IOrientadorRepository
    {
        public OrientadorRepository(AppDbContext context) : base(context)
        {
        }
    }
}