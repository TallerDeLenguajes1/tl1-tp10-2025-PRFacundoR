using System.Runtime.InteropServices;
using System.Text.Json;
using Usuarios;



string rutaArchivo = "Usuarios.json";
Console.WriteLine("Ingres un url");
string url = Console.ReadLine();

 async Task<List<Users>> ReadApiUser(string url)
    {
        HttpClient peticion = new HttpClient();
        HttpResponseMessage respuesta = await peticion.GetAsync(url);
        respuesta.EnsureSuccessStatusCode();

        string responseBody = await respuesta.Content.ReadAsStringAsync();

        List<Users> usuarios = JsonSerializer.Deserialize<List<Users>>(responseBody);

        return usuarios;
    }

void MostrarPrimerosCincoUsuarios(List<Users> lista)
    {
        int contador = 0;

        foreach (var u in lista)
        {
            if (contador == 5)
                break;

            Console.WriteLine($"Nombre: {u.name}");
            Console.WriteLine($"Correo Electrónico: {u.email}");
            Console.WriteLine("Domicilio:");
            Console.WriteLine($"  Calle: {u.address.street}");
            Console.WriteLine($"  Suite: {u.address.suite}");
            Console.WriteLine($"  Ciudad: {u.address.city}");
            Console.WriteLine($"  Código Postal: {u.address.zipcode}");
            Console.WriteLine(new string('-', 40));
            contador++;
        }
    }
 void AgregarUsuarioAlJson(Users usuario, string rutaArchivo)
{
    string json = JsonSerializer.Serialize(usuario);
    File.AppendAllText(rutaArchivo, json + Environment.NewLine);
}

List<Users> usuarios = await ReadApiUser(url);

    
    MostrarPrimerosCincoUsuarios(usuarios);

    
    foreach (var u in usuarios)
    {
        AgregarUsuarioAlJson(u, rutaArchivo);
    }











