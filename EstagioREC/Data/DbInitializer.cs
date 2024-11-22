using Google.Apis.Sheets.v4;
using Google.Apis.Auth.OAuth2;
using EstagioREC.Model;

namespace EstagioREC.Data
{
    public class DbInitializer
    {
        private static readonly string _spreadsheetId = "1OM2DzrsbXG4alxcPqYOTRCTH9GxOsYgIfGPxEY8vFVc";

        public static void RetrieveFromSheets(IApplicationBuilder app) {
            using (var serviceScope = app.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (context == null || context.Orientadores.Any()) 
                    return;
                
                var credential = GoogleCredential.FromFile("client-secrets.json")
                    .CreateScoped(SheetsService.Scope.Spreadsheets);

                var serviceSheets = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "EstagioREC"
                });

                var alunosMap = new Dictionary<string, int>();
                var orientadoresMap = new Dictionary<string, int>();
                var empresaMap = new Dictionary<string, int>();

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
                    orientadoresMap.Add(orientador.Nome, orientador.Id);
                }

                // Obter estagios da planilha
                request = serviceSheets.Spreadsheets.Values.Get(_spreadsheetId, "estagio");
                response = request.Execute();
                values = response.Values;

                if (values == null || values.Count == 0)
                    return;

                foreach (var row in values.Skip(1)) {
                    if (!alunosMap.ContainsKey(row[1].ToString())) {
                        var aluno = new Aluno {
                            Nome = row[0].ToString(),
                            Matricula = row[1].ToString()
                        };
                        context.Alunos.Add(aluno);
                        alunosMap.Add(aluno.Matricula, aluno.Id);
                    }
                    if (!empresaMap.ContainsKey(row[5].ToString())) {
                        var empresa = new Empresa {
                            Nome = row[5].ToString()
                        };
                        context.Empresas.Add(empresa);
                        empresaMap.Add(empresa.Nome, empresa.Id);
                    }
                    var alunoId = alunosMap[row[1].ToString()];
                    var orientadorId = orientadoresMap[row[2].ToString()];
                    var empresaId = empresaMap[row[5].ToString()];
                    
                    var estagio = new Estagio {
                        DatIni = DateTime.Parse(row[3].ToString()),
                        DatFim = DateTime.Parse(row[4].ToString()),
                        Situacao = 0,
                        AlunoId = alunoId,
                        OrientadorId = orientadorId,
                        EmpresaId = empresaId
                    };
                    context.Estagios.Add(estagio);
                }
                context.SaveChanges();
            }
        }
    }
}