using System.Net.Http.Json;
using System.Text.Json;

namespace Decorator;
public class CsvDecorator : IGetCityInformation
{
    private readonly IGetCityInformation _getCityInformation;
    public CsvDecorator(IGetCityInformation getCityInformation)
    {
        _getCityInformation = getCityInformation;
    }
    public async Task GetInfoAsync(string cep)
    {
        await _getCityInformation.GetInfoAsync(cep); //CALL DECORATOR OBJECT

        //FORCE LIB USE.ABSOLUTELY COUPLED. SEE THE ADAPTER PATTERN
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://viacep.com.br/ws/");

        var request = await client.GetAsync($"{cep}/json/");
        if (request.IsSuccessStatusCode)
        {
            var jsonResponse = await request.Content.ReadFromJsonAsync<object>();

            var path = "./files";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (jsonResponse is not null)
            {
                JsonElement element = (JsonElement)jsonResponse;
                var headerLine = "cep;logradouro;complemento;unidade;bairro;localidade;uf;estado;regiao;ibge;gia;ddd;siafi";

                var cepLine = element.GetProperty("cep").GetString();
                var complementoLine = element.GetProperty("complemento").GetString();
                var unidadeLine = element.GetProperty("unidade").GetString();    
                var bairroLine = element.GetProperty("bairro").GetString();
                var localidadeLine = element.GetProperty("localidade").GetString();
                var ufLine = element.GetProperty("uf").GetString();
                var estadoLine = element.GetProperty("estado").GetString();
                var regiaoLine = element.GetProperty("regiao").GetString();
                var ibgeLine = element.GetProperty("ibge").GetString(   );
                var giaLine = element.GetProperty("gia").GetString();
                var dddLine = element.GetProperty("ddd").GetString();
                var siafiLine = element.GetProperty("siafi").GetString();

                var infoLine = $"{cepLine};{complementoLine};{unidadeLine};{bairroLine};{localidadeLine};{ufLine};{estadoLine};{regiaoLine};{ibgeLine};{giaLine};{dddLine};{siafiLine}";

                File.AppendAllLines($"{path}/city.csv", new List<string> { headerLine, infoLine });
                Console.WriteLine("CSV File created");
            }
        }
    }
}
