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

// Create
var valueRange = new ValueRange
{
    Values = listaDadosFake()
};

var range = "estagio!A:G";
var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
// var appendReponse = appendRequest.Execute();

// Read

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
// fields are Aluno (string), Matricula (number), Orientador (string), Inicio Estagio (date), Fim Estagio (date), Empresa (string), Situacao (Andamento, Renovado or Pendente)
List<IList<object>> listaDadosFake() {
    var faker = new Faker("pt_BR");
    var dados = new List<IList<object>>();

    dados.Add(new List<object> { "Aluno", "Matrícula", "Orientador", "Inicio Estágio", "Fim Estágio", "Empresa", "Situação" });
    for (int i=0; i < 1000; i++) {
        var aluno = faker.PickRandom(faker.Name.FullName(Bogus.DataSets.Name.Gender.Female), faker.Name.FullName(Bogus.DataSets.Name.Gender.Male));
        var matricula = faker.Random.Number(100000, 999999);
        var orientador = faker.PickRandom(faker.Name.FullName(Bogus.DataSets.Name.Gender.Female), faker.Name.FullName(Bogus.DataSets.Name.Gender.Male));
        var inicioEstagio = faker.Date.Past();
        var fimEstagio = faker.Date.Future();
        var empresa = faker.Company.CompanyName();
        var situacao = faker.PickRandom("Andamento", "Renovado", "Pendente");
        dados.Add(new List<object> { aluno, matricula, orientador, inicioEstagio, fimEstagio, empresa, situacao });
    }
    return dados;
}