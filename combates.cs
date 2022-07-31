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
        danoProvocado= Math.Round(danoProvocado, 2);
        jugador2.Informacion.Salud -= danoProvocado;
        jugador2.Informacion.Salud = Math.Round(jugador2.Informacion.Salud, 2);
        Console.WriteLine("Efectividad de disparo: " + efectividadDisparo);
        Console.WriteLine("Valor de ataque: " + valorAtaque);
        Console.WriteLine("Danio provocado: " + danoProvocado);
        if (jugador2.Informacion.Salud < 0)
        {
            jugador2.Informacion.Salud= 0;
        }
        Console.WriteLine("LA salud de " + jugador2.Informacion.Nombre + " bajo a " + jugador2.Informacion.Salud);
    }
    private void premioGanador(personaje jugador)
    {
        jugador.Informacion.Salud += 1000;
        Random r = new Random();
        switch (r.Next(1, 6))
        {
            case 1:
                jugador.Poder.Armadura +=1;
                break;
            case 2:
                jugador.Poder.Destreza +=1;
                break;
            case 3:
                jugador.Poder.Fuerza +=1;
                break;
            case 4:
                jugador.Poder.Nivel +=1;
                break;
            case 5:
                jugador.Poder.Velocidad +=1;
                break;
        }
    }
    public personaje combatir(personaje jugador1, personaje jugador2)
    {
        for (int i = 0; i < 3; i++)
        {
            if (jugador1.Informacion.Salud > 0 && jugador2.Informacion.Salud > 0)
            {
                Console.WriteLine("ROUND " + (i+1) + "!!!!\n");
                Console.WriteLine("ATACA: " + jugador1.Informacion.Nombre + "  |---|  DEFIENDE: " + jugador2.Informacion.Nombre);
                ataque(jugador1, jugador2);
                Console.WriteLine("\nAHORA ES TURNO DE QUE ATAQUE " + jugador2.Informacion.Nombre + "  |---|  Y DEFIENDA " + jugador1.Informacion.Nombre);
                ataque(jugador2, jugador1);
            }
        }
        Console.Write("\n");
        if (jugador1.Informacion.Salud > jugador2.Informacion.Salud)
        {
            Console.WriteLine(jugador1.Informacion.Nombre + " ES EL GANADOR!!!!");
            premioGanador(jugador1);
            return jugador2;  //retorna al perdedor para que sea eliminado de la lista
        } else
        {
            if (jugador2.Informacion.Salud > jugador1.Informacion.Salud)
            {
                Console.WriteLine(jugador2.Informacion.Nombre + " ES EL GANADOR!!!!");
                premioGanador(jugador2);
                return jugador1;
            } else
            {
                Console.WriteLine("HA HABIDO UN EMPATE!!! EL GANADOR SE DARA POR SORTEO");
                if (r.Next(1,3) == 1)
                {
                    Console.WriteLine(jugador2.Informacion.Nombre + " ES EL GANADOR!!!!");
                    premioGanador(jugador2);
                    return jugador1;
                } else
                {
                    Console.WriteLine(jugador1.Informacion.Nombre + " ES EL GANADOR!!!!");
                    premioGanador(jugador1);
                    return jugador2;
                }
            }
        }
    }
} 