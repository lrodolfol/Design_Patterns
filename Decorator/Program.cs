using Decorator;
using System.Net.Http.Json;

var getCity = new GetCityInformation();
var getCityCsv = new CsvDecorator(getCity);

await getCityCsv.GetInfoAsync("37470000");

public class GetCityInformation : IGetCityInformation
{
    public async Task GetInfoAsync(string cep)
    {
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

            if(jsonResponse is not null)
            {
                File.WriteAllText($"{path}/city.json", jsonResponse.ToString());
                Console.WriteLine("JSON file created");
            }
        }

        //WE HAVE ONE CLASSE THAT SAVE A RESPONSE TO JSON FORMAT
        //BUT WE WOULD LIKE TO SAVE IN XML FORMAT, ITS NEED TO MODIFICATE THIS CLASS? - NO
        //THIS MODIFICATION WILL BE INTERFER THE 'OPEN/CLOSE PRINCIPLE'. WE NEED TO CREATE A NEW CLASS, ONE INTERFACE AND USE THE DECORATOR PATTERN
    }
}