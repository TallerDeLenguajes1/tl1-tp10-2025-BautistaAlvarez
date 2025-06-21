using System.Text.Json;
using EspacioCatFact;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


string url = "https://catfact.ninja/fact";

HttpClient client = new HttpClient();

HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();

string responseBody = await response.Content.ReadAsStringAsync();
CatFact CatFactito = JsonSerializer.Deserialize<CatFact>(responseBody);//como es un unico dato se escribe de esta manera, no necesario una lista


Console.WriteLine($"Dato curiso sobre los gatos: {CatFactito.Fact}");

string rutaArchivo = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "FactCat.json");
string jsonString = JsonSerializer.Serialize(CatFactito);
using (var writer = new StreamWriter(rutaArchivo)) {
    writer.WriteLine(jsonString);
}