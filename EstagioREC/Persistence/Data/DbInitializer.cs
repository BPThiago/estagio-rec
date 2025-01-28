using System.Globalization;
using Google.Apis.Sheets.v4;
using EstagioREC.Domain;
using EstagioREC.Domain.Enums;

namespace EstagioREC.Persistence.Data
{
    public class DbInitializer
    {
        private static readonly string _spreadsheetId = "1OM2DzrsbXG4alxcPqYOTRCTH9GxOsYgIfGPxEY8vFVc";
        private static readonly string _apiKey = "AIzaSyAq6XkFHMXZiqH1iY6qiJDoPuDk_he2Gbk";

        public static void RetrieveFromSheets(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (context == null || context.Orientadores.Any())
                    return;

                var serviceSheets = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
                {
                    ApiKey = _apiKey,
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

                foreach (var row in values.Skip(1))
                {
                    var orientador = new Orientador
                    {
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

                foreach (var row in values.Skip(1))
                {
                    if (!alunosMap.ContainsKey(row[1].ToString()))
                    {
                        var aluno = new Aluno
                        {
                            Nome = row[0].ToString(),
                            Matricula = row[1].ToString()
                        };
                        context.Alunos.Add(aluno);
                        alunosMap.Add(aluno.Matricula, aluno.Id);
                    }
                    if (!empresaMap.ContainsKey(row[5].ToString()))
                    {
                        var empresa = new Empresa
                        {
                            Nome = row[5].ToString()
                        };
                        context.Empresas.Add(empresa);
                        empresaMap.Add(empresa.Nome, empresa.Id);
                    }
                    var alunoId = alunosMap[row[1].ToString()];
                    var orientadorId = orientadoresMap[row[2].ToString()];
                    var empresaId = empresaMap[row[5].ToString()];

                    var situacao = row[6].ToString() switch
                    {
                        "Pendente" => SituacaoEnum.Pendente,
                        "Andamento" => SituacaoEnum.Andamento,
                        "Renovado" => SituacaoEnum.Renovado,
                        _ => SituacaoEnum.Andamento
                    };

                    var estagio = new Estagio
                    {
                        DatIni = DateTime.ParseExact(row[3].ToString(), "d/M/yyyy", CultureInfo.InvariantCulture),
                        DatFim = DateTime.ParseExact(row[4].ToString(), "d/M/yyyy", CultureInfo.InvariantCulture),
                        Situacao = situacao,
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