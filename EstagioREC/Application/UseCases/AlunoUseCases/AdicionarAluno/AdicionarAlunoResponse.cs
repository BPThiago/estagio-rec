namespace EstagioREC.Application.UseCases.AlunoUseCases.AdicionarAluno;

public sealed record AdicionarAlunoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Matricula { get; set; }
}