using AutoMapper;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.BaseUseCases
{
    public class AtualizarHandler<Request, Response, Entity, IRepository> : IRequestHandler<Request, Response>
        where Entity : BaseEntity
        where Response : BaseResponse
        where Request : IRequest<Response>
        where IRepository : IBaseRepository<Entity>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AtualizarHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; 
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Entity>(request);
            await _repository.AtualizarAsync(entity, cancellationToken);
            return _mapper.Map<Response>(entity);
        }
    }
}
