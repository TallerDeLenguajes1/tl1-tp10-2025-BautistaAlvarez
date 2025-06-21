using System.Text.Json;
using EspacioUsuario;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string url = "https://jsonplaceholder.typicode.com/users";
HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();
string responseBody = await response.Content.ReadAsStringAsync();
List<Usuario> listaUsuario = JsonSerializer.Deserialize<List<Usuario>>(responseBody);

for (int i = 0; i < 5; i++)
{
    var usu = listaUsuario[i];
    Console.WriteLine($"Nombre: {usu.Name}, Correo: {usu.Email}");
    Console.WriteLine($"Domicilio");
    Console.WriteLine($"Calle: {usu.Address.Street}, Suite: {usu.Address.Suite}, ciudad: {usu.Address.City}, Cod. Postal: {usu.Address.Zipcode}, Latitud: {usu.Address.Geo.Lat}, Longitud: {usu.Address.Geo.Lng}");
    Console.WriteLine("-------------------------------------");
}
string rutaReporte = Path.Combine(System.IO.Directory.GetCurrentDirectory(),"usuario.json");
string jsonString = JsonSerializer.Serialize(listaUsuario);
using (var writer = new StreamWriter(rutaReporte))
{
    writer.WriteLine(jsonString);
}
