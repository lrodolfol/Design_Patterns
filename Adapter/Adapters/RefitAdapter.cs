using Refit;

namespace Adapter.Adapters;
public class RefitAdapter : IHttpClientAdapter
{
    public async Task GetRequest(string cep)
    {
        var client = RestService.For<CityInformationApi>("https://viacep.com.br");
        var response = await client.GetCityInformation(cep);

        Console.WriteLine($"Mostrando dados da cidade: {response}");
        
    }
}

public interface CityInformationApi
{
    [Get("/ws/{cep}/json/")]
    Task<object> GetCityInformation(string cep);
}