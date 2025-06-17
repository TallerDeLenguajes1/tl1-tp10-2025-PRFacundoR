using System.Globalization;
using System.Text.Json;
using tareas;

// See https://aka.ms/new-console-template for more information

//
//
//

Console.WriteLine("Ingres un url");
string url = Console.ReadLine();

HttpClient peticion = new HttpClient(); //traigo informacion de la web
           
HttpResponseMessage respuesta = await peticion.GetAsync(url);
           
respuesta.EnsureSuccessStatusCode();


string responseBody = await respuesta.Content.ReadAsStringAsync();
List<Tarea> listTareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody);

foreach (var listT in listTareas)
{
    if (listT.completed == true)
    {
        Console.WriteLine("Titulo de la tarea: " + listT.title);
        Console.WriteLine("Estado de la tarea, completado");

    }


   

}



foreach (var listT in listTareas)
{
    if (listT.completed == false)
    {
        Console.WriteLine("Titulo de la tarea: " + listT.title);
        Console.WriteLine("Estado de la tarea, pendiente");

    }


}
string jsonString = JsonSerializer.Serialize(listTareas);

string ruta = "tareas.json";

File.AppendAllText(ruta, jsonString + Environment.NewLine);




