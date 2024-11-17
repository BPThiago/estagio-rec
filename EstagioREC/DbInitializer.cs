using Google.Apis.Sheets.v4;
using Google.Apis.Auth.OAuth2;

namespace EstagioREC
{
    public class DbInitializer
    {
        private static readonly string _spreadsheetId = "1OM2DzrsbXG4alxcPqYOTRCTH9GxOsYgIfGPxEY8vFVc";

        public static void RetrieveFromSheets(IApplicationBuilder app) {
            using (var serviceScope = app.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<EstagioDb>();

                if (context == null || context.Orientadores.Any()) 
                    return;
                
                var credential = GoogleCredential.FromFile("client-secrets.json")
                    .CreateScoped(SheetsService.Scope.Spreadsheets);

                var serviceSheets = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "EstagioREC"
                });

                // Obter orientadores da planilha
                var request = serviceSheets.Spreadsheets.Values.Get(_spreadsheetId, "orientador");
                var response = request.Execute();
                var values = response.Values;

                if (values == null || values.Count == 0)
                    return;

                foreach (var row in values.Skip(1)) {
                    var orientador = new Orientador {
                        Nome = row[0].ToString(),
                        Email = row[1].ToString(),
                        Telefone = row[2].ToString()
                    };

                    context.Orientadores.Add(orientador);
                }
                context.SaveChanges();
            }
        }
    }
}