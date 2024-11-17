using Microsoft.EntityFrameworkCore;

namespace EstagioREC
{
    public class EstagioDb : DbContext
    {
        public EstagioDb(DbContextOptions<EstagioDb> options)
            : base(options) {}
        
        public DbSet<Orientador> Orientadores => Set<Orientador>();
    }
}