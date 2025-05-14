using Adapter;
using Adapter.Adapters;
using RestSharp;
using System.Threading.Channels;


var restSharpAdapter = new RestSharpAdapter();
//var restSharpAdapter = new RefitAdapter();
var getCity =  new GetCityInformation(restSharpAdapter);
string cep = "37470000";

await getCity.GetInfo(cep);


public class GetCityInformation
{
    private readonly IHttpClientAdapter _httpClientAdapter;

    public GetCityInformation(IHttpClientAdapter httpClientAdapter)
    {
        _httpClientAdapter = httpClientAdapter;
    }

    public async Task GetInfo(string cep)
    {
        //FORCE LIB USE. ABSOLUTELY COUPLED
        //var rest = new RestClient("https://viacep.com.br/ws/" + cep + "/json/");
        //var request = new RestRequest();
        //var response = await rest.ExecuteAsync(request);

        //if (! response.IsSuccessful)
        //    Console.WriteLine("Dados não encontrados");
        //else
        //    Console.WriteLine($"Mostrando dados da cidade: {response.Content}");

        await _httpClientAdapter.GetRequest(cep);
    }
}