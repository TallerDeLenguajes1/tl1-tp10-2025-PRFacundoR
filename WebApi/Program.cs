// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using WebApi;


string rutaArchivo = "DogImages.json";
Console.WriteLine("Ingres un url");
string url = Console.ReadLine();

 async Task<DogImage> ReadApiUser(string url)
    {
        HttpClient peticion = new HttpClient();
        HttpResponseMessage respuesta = await peticion.GetAsync(url);
        respuesta.EnsureSuccessStatusCode();

        string responseBody = await respuesta.Content.ReadAsStringAsync();

        DogImage Dog = JsonSerializer.Deserialize<DogImage>(responseBody);

        return Dog;
    }

void MostrarDogImages(DogImage DogImagesList)
    {
        

   
        Console.WriteLine($"Mensaje: {DogImagesList.message}");

        
       
            

    }
 void AgregarAlJson(DogImage DogImages, string rutaArchivo)
{
    string json = JsonSerializer.Serialize(DogImages);
    File.AppendAllText(rutaArchivo, json + Environment.NewLine);
}

DogImage DogImages = await ReadApiUser(url);

    
    MostrarDogImages(DogImages);

    

    AgregarAlJson(DogImages, rutaArchivo);
    