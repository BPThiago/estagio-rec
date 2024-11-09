using Google.Apis.Sheets.v4;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4.Data;

var credential = GoogleCredential.FromFile("client-secrets.json")
    .CreateScoped(SheetsService.Scope.Spreadsheets);

String spreadsheetId = "inserir-chave";

var service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
{
    HttpClientInitializer = credential,
    ApplicationName = "EstagioREC"
});

// Create
var valueRange = new ValueRange();

var objectList = new List<object>() { "Teste", "Teste" };
valueRange.Values = new List<IList<object>> { objectList };

var range = "datasets!A:B";
var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
var appendReponse = appendRequest.Execute();

// Read

var request = service.Spreadsheets.Values.Get(
    spreadsheetId, "datasets"
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