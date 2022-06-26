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

    public void combatir(personaje jugador1, personaje jugador2)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("ROUND " + i+1);
            Console.WriteLine("Ataca :" + jugador1.Informacion.Nombre + " Defiende: " + jugador2.Informacion.Nombre);
            double efectividadDisparo= r.Next(0,101) / 100.00;
            double valorAtaque= calcularVA(jugador1, efectividadDisparo);
            int poderDefensa= calcularPDEF(jugador2);
            double danoProvocado = (((valorAtaque * efectividadDisparo) - poderDefensa) / MDP) * 100;
            jugador2.Informacion.Salud -= Convert.ToInt32(danoProvocado);

            Console.WriteLine("Ahora es turno de que ataque :" + jugador2.Informacion.Nombre + " y defienda: " + jugador1.Informacion.Nombre);
            efectividadDisparo= r.Next(0,101) / 100.00;
            valorAtaque= calcularVA(jugador2, efectividadDisparo);
            poderDefensa= calcularPDEF(jugador1);
            danoProvocado = (((valorAtaque * efectividadDisparo) - poderDefensa) / MDP) * 100;
            jugador1.Informacion.Salud -= Convert.ToInt32(danoProvocado);
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