using Microsoft.EntityFrameworkCore;
using EstagioREC.Model;

namespace EstagioREC.Data
{
    /*Estagio Setor*/
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {}
        
        public DbSet<Orientador> Orientadores => Set<Orientador>();
        public DbSet<Aluno> Alunos => Set<Aluno>();
        public DbSet<Empresa> Empresas => Set<Empresa>();
        public DbSet<Estagio> Estagios => Set<Estagio>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estagio>()
                .HasOne(e => e.Aluno)
                .WithMany(a => a.Estagios) 
                .HasForeignKey(e => e.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Estagio>()
                .HasOne(o => o.Orientador)
                .WithMany(e => e.Estagios) 
                .HasForeignKey(o => o.OrientadorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Estagio>()
                .HasOne(e => e.Empresa)
                .WithMany()
                .HasForeignKey(e => e.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}