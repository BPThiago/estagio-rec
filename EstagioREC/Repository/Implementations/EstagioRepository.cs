using EstagioREC.Data;
using EstagioREC.Model;
using Microsoft.EntityFrameworkCore;

namespace EstagioREC.Repository.Implementations
{
    public class EstagioRepository : IEstagioRepository
    {
        private readonly AppDbContext _context;

        public EstagioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Estagio> ObterPorIdAsync(int id)
        {
            var estagio = await _context.Estagios.FindAsync(id);
            AssociarAlunoOrientadorEmpresa(estagio);
            return estagio;
        }
        public async Task<IEnumerable<Estagio>> ObterTodosAsync()
        {
            List<Estagio> estagios = await _context.Estagios.ToListAsync();
            estagios.ForEach(e => AssociarAlunoOrientadorEmpresa(e));
            return estagios;
        }

        public async Task<Estagio> AdicionarAsync(Estagio estagio)
        {
            if (estagio == null)
                throw new ArgumentNullException(nameof(estagio));

            try
            {
                AssociarAlunoOrientadorEmpresa(estagio);

                _context.Estagios.Add(estagio);
                await _context.SaveChangesAsync();
                return estagio;

            }  catch (Exception e)
            {
                throw new Exception("Erro ao adicionar estagio", e);
            }
        }

        public async Task AtualizarAsync(Estagio estagio)
        {
            AssociarAlunoOrientadorEmpresa(estagio);
            _context.Entry(estagio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var estagio = await _context.Estagios.FindAsync(id);
            if (estagio == null)
                return;

            _context.Estagios.Remove(estagio);
            await _context.SaveChangesAsync();
        }

        private void AssociarAlunoOrientadorEmpresa(Estagio estagio)
        {
            estagio.Aluno = _context.Alunos.FirstOrDefault(a => a.Id == estagio.AlunoId)
                ?? throw new InvalidOperationException($"Aluno com ID {estagio.AlunoId} não encontrado.");
            estagio.Orientador = _context.Orientadores.FirstOrDefault(o => o.Id == estagio.OrientadorId)
                ?? throw new InvalidOperationException($"Orientador com ID {estagio.OrientadorId} não encontrado.");
            estagio.Empresa = _context.Empresas.FirstOrDefault(e => e.Id == estagio.EmpresaId)
                ?? throw new InvalidOperationException($"Empresa com ID {estagio.EmpresaId} não encontrada.");
        }
    }
}
