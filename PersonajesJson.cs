using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class PersonajesJson
{
    // Método para guardar una lista de personajes en un archivo JSON
    public static void GuardarPersonajes(List<Personaje> personajes, string nombreArchivo)
    {
        try
        {
            // Serializar la lista de personajes a formato JSON
            string jsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions { WriteIndented = true });

            // Escribir el JSON en el archivo especificado
            File.WriteAllText(nombreArchivo, jsonString);

            Console.WriteLine($"Se han guardado {personajes.Count} personajes en {nombreArchivo}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar el archivo JSON: {ex.Message}");
        }
    }

    // Método para leer personajes desde un archivo JSON y retornarlos como una lista
    public static List<Personaje> LeerPersonajes(string nombreArchivo)
    {
        List<Personaje> personajes = new List<Personaje>();

        try
        {
            // Verificar si el archivo JSON existe
            if (File.Exists(nombreArchivo))
            {
                // Leer el JSON desde el archivo
                string jsonString = File.ReadAllText(nombreArchivo);

                // Deserializar el JSON a una lista de personajes
                personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonString);

                Console.WriteLine($"Se han cargado {personajes.Count} personajes desde {nombreArchivo}");
            }
            else
            {
                Console.WriteLine($"El archivo {nombreArchivo} no existe. No se cargaron personajes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
        }

        return personajes;
    }

    // Método para verificar si un archivo existe y tiene datos
    public static bool Existe(string nombreArchivo)
    {
        try
        {
            // Verificar si el archivo existe y tiene datos
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al verificar la existencia del archivo JSON: {ex.Message}");
            return false;
        }
    }
}
