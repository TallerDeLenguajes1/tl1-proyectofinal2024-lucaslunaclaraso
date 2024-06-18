using System.Globalization;

public class Personaje
{
    //Caracteristicas
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;

    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
    public int Destreza { get => destreza; set => destreza = value; }


    // DATOS

    private string tipo;
    private string nombre;
    private string apodo;
    private DateTime fechaDeNacimiento;
    private int edad;


    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public int Edad { get => edad; set => edad = value; }



    // CONSTRUCTOR

    public Personaje(string tipo, string nombre, string apodo, DateTime fechaDeNacimiento)
    {
        Tipo = tipo;
        Nombre = nombre;
        Apodo = apodo;
        FechaDeNacimiento = fechaDeNacimiento;
        Edad = DateTime.Now.Year - fechaDeNacimiento.Year;


        Random rnd = new Random();

        Velocidad = rnd.Next(1, 11);
        Destreza = rnd.Next(1, 6);
        Fuerza = rnd.Next(1, 11);
        Nivel = rnd.Next(1, 11);
        Armadura = rnd.Next(1, 11);
        Salud = 100;

    }




    public void MostrarDatosPersonaje()
    {

        Console.WriteLine("Tipo: " + Tipo);
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Apodo: " + Apodo);
        Console.WriteLine("Fecha de nacimiento: " + FechaDeNacimiento);
        Console.WriteLine("Edad: " + Edad);
        Console.WriteLine("Velocidad: " + Velocidad);
        Console.WriteLine("Destreza: " + Destreza);
        Console.WriteLine("Fuerza: " + Fuerza);
        Console.WriteLine("Nivel: " + Nivel);
        Console.WriteLine("Armadura: " + Armadura);
        Console.WriteLine("Salud: " + Salud);
        Console.WriteLine();
    }


}