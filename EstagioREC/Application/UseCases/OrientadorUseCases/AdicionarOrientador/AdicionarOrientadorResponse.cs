namespace EstagioREC.Application.UseCases.OrientadorUseCases.AdicionarOrientador
{
    public sealed record AdicionarOrientadorResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
