namespace EstagioREC.Application.UseCases.EmpresaUseCases.AdicionarEmpresa;

public sealed record AdicionarEmpresaResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
}