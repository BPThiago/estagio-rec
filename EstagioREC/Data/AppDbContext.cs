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
            // Configuração do relacionamento entre Estagio e Aluno
            modelBuilder.Entity<Estagio>()
                .HasOne(e => e.Aluno)
                .WithMany() // Caso Aluno tenha uma coleção de Estagios
                .HasForeignKey(e => e.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração do relacionamento entre Estagio e Orientador
            modelBuilder.Entity<Estagio>()
                .HasOne(e => e.Orientador)
                .WithMany() // Caso Orientador tenha uma coleção de Estagios
                .HasForeignKey(e => e.OrientadorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração do relacionamento entre Estagio e Empresa
            modelBuilder.Entity<Estagio>()
                .HasOne(e => e.Empresa)
                .WithMany()
                .HasForeignKey(e => e.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}