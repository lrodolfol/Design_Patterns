using RestSharp;

namespace Adapter.Adapters;
internal class RestSharpAdapter : IHttpClientAdapter
{
    public async Task GetRequest(string cep)
    {
        var rest = new RestClient($"https://viacep.com.br/ws/{cep}/json/");
        var request = new RestRequest();
        var response = await rest.ExecuteAsync(request);

        if (!response.IsSuccessful)
            Console.WriteLine("Dados não encontrados");
        else
            Console.WriteLine($"Mostrando dados da cidade: {response.Content}");
    }
}
