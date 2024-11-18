using Microsoft.EntityFrameworkCore;
using EstagioREC.Model;

namespace EstagioREC.Data
{
    /*Estagio Setor*/
    public class EstagioDb : DbContext
    {
        public EstagioDb(DbContextOptions<EstagioDb> options)
            : base(options) {}
        
        public DbSet<Orientador> Orientadores => Set<Orientador>();
        public DbSet<Aluno> Alunos => Set<Aluno>();
    }
}