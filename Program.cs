class Program
{
    static void Main()
    {
        // Crear una lista de personajes aleatorios
        List<Personaje> personajes = new List<Personaje>();
        for (int i = 1; i <= 10; i++)
        {
            personajes.Add(FabricaDePersonajes.crearPersonje());
        }

        // Nombre del archivo donde se guardarán los personajes
        string nombreArchivo = "personajes.json";

        // Guardar los personajes en el archivo JSON
        PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);

        // Leer los personajes desde el archivo JSON
        List<Personaje> personajesDesdeArchivo = PersonajesJson.LeerPersonajes(nombreArchivo);

        // Mostrar la información de los personajes leídos
        Console.WriteLine("\nPersonajes cargados desde el archivo:");
        foreach (var personaje in personajesDesdeArchivo)
        {
            personaje.MostrarDatosPersonaje();
            Console.WriteLine();
        }

        // Verificar la existencia del archivo
        bool archivoExiste = PersonajesJson.Existe(nombreArchivo);
        Console.WriteLine($"El archivo {nombreArchivo} existe y tiene datos: {archivoExiste}");

        // Esperar hasta que el usuario presione una tecla para salir
        Console.ReadKey();
    }

}
