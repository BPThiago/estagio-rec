using Microsoft.EntityFrameworkCore;
using EstagioREC.Model;

namespace EstagioREC.Data
{
    public class EstagioDb : DbContext
    {
        public EstagioDb(DbContextOptions<EstagioDb> options)
            : base(options) {}
        
        public DbSet<Orientador> Orientadores => Set<Orientador>();
    }
}