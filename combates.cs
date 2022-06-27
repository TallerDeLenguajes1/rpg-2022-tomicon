// See https://aka.ms/new-console-template for more information
public class combates{
    const int MDP = 50000;
    Random r = new Random();

    public combates()
    {
    }

    private int calcularPD(personaje jugador)
    {
        int poderDisparo= jugador.Poder.Destreza * jugador.Poder.Fuerza * jugador.Poder.Nivel;
        return poderDisparo;
    }

    private double calcularVA(personaje jugador, double efectividadDisparo)
    {
        var poderDisparo = calcularPD(jugador);
        double valorAtaque = poderDisparo * efectividadDisparo;
        return valorAtaque;
    }
    private int calcularPDEF(personaje jugador)
    {
        int PoderDefensa= jugador.Poder.Armadura * jugador.Poder.Velocidad;
        return PoderDefensa;
    }

    private void ataque(personaje jugador1, personaje jugador2)
    {
        double efectividadDisparo= r.Next(0,101);
        double valorAtaque= calcularVA(jugador1, efectividadDisparo);
        int poderDefensa= calcularPDEF(jugador2);
        double danoProvocado = (((valorAtaque * efectividadDisparo) - poderDefensa) / MDP) * 100;
        jugador2.Informacion.Salud -= danoProvocado;
        Console.WriteLine("Efectividad de disparo: " + efectividadDisparo);
        Console.WriteLine("Valor de ataque: " + valorAtaque);
        Console.WriteLine("Danio provocado: " + danoProvocado);
        if (jugador2.Informacion.Salud < 0)
        {
            jugador2.Informacion.Salud= 0;
        }
        Console.WriteLine("LA salud de " + jugador2.Informacion.Nombre + " bajo a " + jugador2.Informacion.Salud);
    }
    public void combatir(personaje jugador1, personaje jugador2)
    {
        for (int i = 0; i < 3; i++)
        {
            if (jugador1.Informacion.Salud > 0 && jugador2.Informacion.Salud > 0)
            {
                Console.WriteLine("ROUND " + (i+1));
                Console.WriteLine("Ataca :" + jugador1.Informacion.Nombre + " Defiende: " + jugador2.Informacion.Nombre);
                ataque(jugador1, jugador2);
                Console.WriteLine("Ahora es turno de que ataque " + jugador2.Informacion.Nombre + " y defienda " + jugador1.Informacion.Nombre);
                ataque(jugador2, jugador1);
            }
        }
        if (jugador1.Informacion.Salud > jugador2.Informacion.Salud)
        {
            Console.WriteLine(jugador1.Informacion.Nombre + " ES EL GANADOR!!!!");
        } else
        {
            if (jugador2.Informacion.Salud > jugador1.Informacion.Salud)
            {
                Console.WriteLine(jugador1.Informacion.Nombre + " ES EL GANADOR!!!!");
            } else
            {
                Console.WriteLine("HA HABIDO UN EMPATE!!!");
            }
        }
    }
} 