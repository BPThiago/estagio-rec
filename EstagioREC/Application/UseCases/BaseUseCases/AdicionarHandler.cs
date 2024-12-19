using AutoMapper;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.BaseUseCases
{
    public class AdicionarHandler<Request, Response, Entity, IRepository> : IRequestHandler<Request, Response>
        where Entity : BaseEntity
        where Response : BaseResponse
        where Request : IRequest<Response>
        where IRepository : IBaseRepository<Entity>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AdicionarHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; 
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Entity>(request);
            await _repository.AdicionarAsync(entity, cancellationToken);
            return _mapper.Map<Response>(entity);
        }
    }
}
