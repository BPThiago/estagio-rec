using AutoMapper;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.BaseUseCases
{
    public class ObterTodosHandler<Request, Response, Entity, IRepository> : IRequestHandler<Request, List<Response>>
        where Entity : BaseEntity
        where Response : BaseResponse
        where Request : IRequest<List<Response>>
        where IRepository : IBaseRepository<Entity>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ObterTodosHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; 
        }

        public async Task<List<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var entities = await _repository.ObterTodosAsync(cancellationToken);
            return _mapper.Map<List<Response>>(entities);
        }
    }
}
