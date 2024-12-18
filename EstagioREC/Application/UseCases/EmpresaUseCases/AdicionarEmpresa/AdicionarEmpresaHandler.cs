using AutoMapper;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.AdicionarEmpresa
{
    public class AdicionarEmpresaHandler : IRequestHandler<AdicionarEmpresaRequest, AdicionarEmpresaResponse>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public AdicionarEmpresaHandler(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper; 
        }

        public async Task<AdicionarEmpresaResponse> Handle(AdicionarEmpresaRequest request, CancellationToken cancellationToken)
        {
            var empresa = _mapper.Map<Empresa>(request);
            await _empresaRepository.AdicionarAsync(empresa, cancellationToken);
            return _mapper.Map<AdicionarEmpresaResponse>(empresa);
        }
    }
}