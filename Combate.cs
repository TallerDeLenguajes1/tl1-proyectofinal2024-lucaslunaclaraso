public class Combate
{
    private Personaje _personaje1;
    private Personaje _personaje2;
    private int _turno;
    private List<Personaje> _personajes;
    private string _archivoJson;

    public Combate(Personaje personaje1, Personaje personaje2, List<Personaje> personajes, string archivoJson)
    {
        _personaje1 = personaje1;
        _personaje2 = personaje2;
        _personajes = personajes;
        _archivoJson = archivoJson;
        _turno = 0;
    }

    public void IniciarCombate()
    {
        while (_personaje1.Salud > 0 && _personaje2.Salud > 0)
        {
            if (_turno % 2 == 0)
            {
                Atacar(_personaje1, _personaje2);
            }
            else
            {
                Atacar(_personaje2, _personaje1);
            }
            _turno++;
        }

        if (_personaje1.Salud <= 0)
        {
            Console.WriteLine($"{_personaje1.Nombre} ha sido derrotado.");
            EliminarPersonaje(_personaje1);
            MejorarPersonaje(_personaje2);
        }
        else
        {
            Console.WriteLine($"{_personaje2.Nombre} ha sido derrotado.");
            EliminarPersonaje(_personaje2);
            MejorarPersonaje(_personaje1);
        }

        // Guardar la lista actualizada de personajes en el archivo JSON
         PersonajesJson.GuardarPersonajes(_personajes, _archivoJson);
    }

    private void Atacar(Personaje atacante, Personaje defensor)
    {
       Random random = new Random();
        int efectividad = random.Next(1, 101);
        int ataque = atacante.Destreza * atacante.Fuerza * atacante.Nivel;
        int defensa = defensor.Armadura * defensor.Velocidad;
        int dañoProvocado = ((ataque * efectividad) - defensa) / 500;

        if (dañoProvocado > 0)
        {
            defensor.Salud -= dañoProvocado;
            Console.WriteLine($"{atacante.Nombre} ataca a {defensor.Nombre} y causa {dañoProvocado} de daño.");
        }
        else
        {
            Console.WriteLine($"{atacante.Nombre} ataca a {defensor.Nombre} pero no causa daño.");
        }
    }

    private void EliminarPersonaje(Personaje personaje)
    {
        _personajes.Remove(personaje);
    }

    private void MejorarPersonaje(Personaje personaje)
    {
        personaje.Salud += 10;  // Mejora en salud
        personaje.Destreza += 5; // Mejora en Destreza
        personaje.Fuerza += 3;// Mejora en Fuerza
    }
}
