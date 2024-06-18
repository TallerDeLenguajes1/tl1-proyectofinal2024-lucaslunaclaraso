using System;
public class FabricaDePersonajes
{
    public static Personaje crearPersonje()
    {
        string[] nombres = { "John", "Lucas", "Bruno", "Esteban", "Sofia", "Lucia", "Franco", "Milagros" };
        string[] tipos = { "Guerrero", "Mago", "Arquero", "Ladrón", "Hechicero" };
        string[] apodos = {
    "El Valiente", "El Sabio", "El Audaz", "El Fuerte", "El Rápido",
    "La Veloz", "La Audaz", "El Justiciero", "El Intrépido", "El Luminoso"
};

        Random rnd = new Random();
        DateTime fechaNacimiento = GenerarFechaNacimiento();

        // Seleccionar nombre y apodo aleFatorio
        string tipo = tipos[rnd.Next(tipos.Length)];
        string nombre = nombres[rnd.Next(nombres.Length)];
        string apodo = apodos[rnd.Next(apodos.Length)];

        Personaje personaje = new Personaje(tipo, nombre, apodo, fechaNacimiento);


        return personaje;
    }



    // Método privado para generar una fecha de nacimiento aleatoria
    private static DateTime GenerarFechaNacimiento()
    {
        Random rnd = new Random();
        DateTime startDate = new DateTime(1970, 1, 1); // Fecha mínima para nacimiento
        int range = (DateTime.Today - startDate).Days; // Rango de días desde 1970 hasta hoy
        return startDate.AddDays(rnd.Next(range)); // Fecha aleatoria entre 1970 y hoy
    }
}