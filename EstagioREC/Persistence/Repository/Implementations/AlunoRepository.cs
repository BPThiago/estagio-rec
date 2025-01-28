using Microsoft.EntityFrameworkCore;
using EstagioREC.Domain;
using EstagioREC.Persistence.Data;
using EstagioREC.Persistence.Repository.Interfaces;

namespace EstagioREC.Persistence.Repository.Implementations
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(AppDbContext context) : base(context)
        {
        }
    }
}

