using System.Reflection;
using Newtonsoft.Json;

int count = 10;
int i = 0;
while (i < count)
{
    var client = new HttpClient();
    var uri = new Uri("https://data.buienradar.nl/2.0/feed/json");
    var stringresponse = await client.GetStringAsync(uri);

    var BuienradarModel = JsonConvert.DeserializeObject<Root>(stringresponse);
    var results = Analysis.Averages(BuienradarModel);

    foreach (PropertyInfo prop in results.GetType().GetProperties())
    {
        Console.WriteLine($"{prop.Name} : {prop.GetValue(results, null).ToString()}");
    }


    // var path = Path.GetFullPath("/home/kris/repo/testing/pullDatatest/pullingdata");

    using StreamWriter file = new("weather.txt", append: true);

    var prefix = $"Current DateTime: {DateTime.Now} with index {i}, ";
    await file.WriteLineAsync(prefix + stringresponse);
    Thread.Sleep(600000);
    i++;
}