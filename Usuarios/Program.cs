using System.Runtime.InteropServices;
using System.Text.Json;
using Usuarios;


int Usuarios = 0;
Console.WriteLine("Ingres un url");
string url = Console.ReadLine();

HttpClient peticion = new HttpClient(); //traigo informacion de la web
           
HttpResponseMessage respuesta = await peticion.GetAsync(url);
           
respuesta.EnsureSuccessStatusCode();


string responseBody = await respuesta.Content.ReadAsStringAsync();
List<Users> listUsuarios = JsonSerializer.Deserialize<List<Users>>(responseBody);

foreach (var listU in listUsuarios)
{


    if (Usuarios == 5)
    {
        break;
    }
    Console.WriteLine("Nombre: " + listU.name);
    Console.WriteLine("Correo Electronico: " + listU.email);
    Console.WriteLine("Domicilio: " + listU.address.street);
    Console.WriteLine(listU.address.suite);
    Console.WriteLine(listU.address.city);
    Console.WriteLine(listU.address.zipcode);
    Usuarios++;
}




string jsonString = JsonSerializer.Serialize(listUsuarios);

string ruta = "Usuarios.json";

File.AppendAllText(ruta, jsonString + Environment.NewLine);




