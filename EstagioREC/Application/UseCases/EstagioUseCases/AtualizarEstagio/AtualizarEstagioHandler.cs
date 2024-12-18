using AutoMapper;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.AtualizarEstagio;

public class AtualizarEstagioHandler : IRequestHandler<AtualizarEstagioRequest, AtualizarEstagioResponse>
{
    private readonly IEstagioRepository _estagioRepository;
    private readonly IMapper _mapper;

    public AtualizarEstagioHandler(IEstagioRepository estagioRepository, IMapper mapper)
    {
        _estagioRepository = estagioRepository;
        _mapper = mapper;
    }

    public async Task<AtualizarEstagioResponse> Handle(AtualizarEstagioRequest request,
        CancellationToken cancellationToken)
    {
        var estagio = _mapper.Map<Estagio>(request.Id);

        if (estagio is null)
            return default;
        
        estagio.DatIni = request.DatIni;
        estagio.DatFim = request.DateFim;
        estagio.Situacao = request.Situacao;
        estagio.EmpresaId = request.EmpresaId;
        estagio.OrientadorId = request.OrientadorId;
        estagio.AlunoId = request.AlunoId;
        
        await _estagioRepository.AtualizarAsync(estagio, cancellationToken);
        
        return _mapper.Map<AtualizarEstagioResponse>(estagio);
    }
}
