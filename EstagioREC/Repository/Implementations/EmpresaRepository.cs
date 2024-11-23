using Microsoft.EntityFrameworkCore;
using EstagioREC.Model;
using EstagioREC.Data;

namespace EstagioREC.Repository 
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AppDbContext _context;

        public EmpresaRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<Empresa> ObterPorIdAsync(int id) {
            return await _context.Empresas.FindAsync(id);
        }

        public async Task<IEnumerable<Empresa>> ObterTodosAsync() {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<Empresa> AdicionarAsync(Empresa empresa) {
            if (empresa == null)
                throw new ArgumentNullException(nameof(empresa));
            
            try 
            {
                _context.Empresas.Add(empresa);
                await _context.SaveChangesAsync();
                return empresa;
            } catch (Exception e) 
            {
                throw new Exception("Erro ao adicionar empresa", e);    
            }
        }

        public async Task AtualizarAsync(Empresa empresa) {
            _context.Entry(empresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
                return;
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
        }
        
    }
}