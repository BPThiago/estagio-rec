namespace EstagioREC.Application.UseCases.BaseUseCases
{
    public sealed record AlunoResponse : BaseResponse
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
    }
}
