using Google.Apis.Sheets.v4;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4.Data;
using Bogus;

var credential = GoogleCredential.FromFile("client-secrets.json")
    .CreateScoped(SheetsService.Scope.Spreadsheets);

String spreadsheetId = "1OM2DzrsbXG4alxcPqYOTRCTH9GxOsYgIfGPxEY8vFVc";

var service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
{
    HttpClientInitializer = credential,
    ApplicationName = "EstagioREC"
});

// Adicionar orientadores
var orientadores = geraDadosOrientador();
var valueRangeOrientador = new ValueRange
{
    Values = orientadores
};

var rangeOrientador = "orientador!A:C";
var appendRequestOrientador = service.Spreadsheets.Values.Append(valueRangeOrientador, spreadsheetId, rangeOrientador);
appendRequestOrientador.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
var appendResponseOrientador = appendRequestOrientador.Execute();

// Adicionar alunos
var alunos = geraDadosAluno(orientadores.Skip(1).Select(o => o[0].ToString()).ToList());
var valueRangeAluno = new ValueRange
{
    Values = alunos
};

var rangeAluno = "estagio!A:G";
var appendRequestAluno = service.Spreadsheets.Values.Append(valueRangeAluno, spreadsheetId, rangeAluno);
appendRequestAluno.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
var appendResponseAluno = appendRequestAluno.Execute();

// Exemplo leitura

var request = service.Spreadsheets.Values.Get(
    spreadsheetId, "estagio"
);

var response = request.Execute();
var values = response.Values;
if (values != null && values.Count > 0)
{
    foreach (var row in values)
    {
        Console.WriteLine("{0}, {1}", row[0], row[1]);
    }
}
else
{
    Console.WriteLine("No data found.");
}

// generate list of fake data using Bogus

// fields are Nome (string), Telefone (string), Email (string)
List<IList<object>> geraDadosOrientador() { 
    var faker = new Faker("pt_BR");
    var dados = new List<IList<object>>();

    dados.Add(new List<object> { "Nome", "Telefone", "Email" });
    for (int i=0; i < 20; i++)
    {
        var nome = faker.Name.FullName();
        var telefone = faker.Phone.PhoneNumber("(27)9####-####");
        var email = faker.Internet.Email(nome.Split(" ")[0], nome.Split(" ")[^1]);

        dados.Add(new List<object> { nome, telefone, email });
    }
    return dados;
}

// fields are Aluno (string), Matricula (number), Orientador (string), Inicio Estagio (date), Fim Estagio (date), Empresa (string), Situacao (Andamento, Renovado or Pendente)
List<IList<object>> geraDadosAluno(List<string?> orientadorNomes) {
    var faker = new Faker("pt_BR");
    var dados = new List<IList<object>>();

    dados.Add(new List<object> { "Aluno", "Matrícula", "Orientador", "Inicio Estágio", "Fim Estágio", "Empresa", "Situação" });
    for (int i=0; i < 1000; i++) {
        var ano = faker.Random.Number(2020, 2024);
        var semestre = faker.Random.Number(1, 2);
        var curso = faker.Random.String2(faker.Random.Number(3, 4));
        var cod = faker.Random.Number(1000, 9999);
        var matricula = $"{ano}{semestre}{curso}{cod}";
        var aluno = faker.Name.FullName();
        var orientador = faker.PickRandom(orientadorNomes);
        var inicioEstagio = faker.Date.Past().ToString("dd'/'MM'/'yyyy");
        var fimEstagio = faker.Date.Future(2).ToString("dd'/'MM'/'yyyy");
        var empresa = faker.Company.CompanyName();
        var situacao = faker.PickRandom("Andamento", "Renovado", "Pendente");

        dados.Add(new List<object> { aluno, matricula, orientador, inicioEstagio, fimEstagio, empresa, situacao });
    }
    return dados;
}