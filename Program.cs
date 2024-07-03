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

        Random random = new Random();

        if (archivoExiste)
        {
            // Realizar combates hasta que solo quede un personaje
            while (personajesDesdeArchivo.Count > 1)
            {
                // Elegir dos personajes aleatorios para el combate
                int index1 = random.Next(personajesDesdeArchivo.Count);
                Personaje personaje1 = personajesDesdeArchivo[index1];

                int index2;
                do
                {
                    index2 = random.Next(personajesDesdeArchivo.Count);
                } while (index2 == index1);

                Personaje personaje2 = personajesDesdeArchivo[index2];

                // Iniciar el combate entre los dos personajes aleatorios
                Combate combate = new Combate(personaje1, personaje2, personajesDesdeArchivo, nombreArchivo);
                combate.IniciarCombate();
                // Esperar hasta que el usuario presione una tecla para la siguiente pelea
            // Esperar hasta que el usuario presione una tecla para la siguiente pelea
            try
            {
                Console.WriteLine("Presione una tecla para iniciar la siguiente pelea...");
                Console.ReadKey();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error al esperar la entrada del usuario: " + ex.Message);
                break;
            }
            }
            // Mostrar el ganador
            if (personajesDesdeArchivo.Count == 1)
            {
                Console.WriteLine("El ganador es:");
                personajesDesdeArchivo[0].MostrarDatosPersonaje();
            }
        }
        // // Esperar hasta que el usuario presione una tecla para salir
        // Console.ReadKey();
    }

}
