// See https://aka.ms/new-console-template for more information
Console.WriteLine("BIENVENIDO A \"THE IRON THRONE TOURNAMENT\"!!!!!! TE CREES CAPAZ DE ALCANZAR LA GLORIA DEL TRONO DE HIERRO??\n");
Console.WriteLine("La dinamica es muy simple. Se hara un torneo entre al menos 8 jugadores. En cada ronda se enfrentaran dos jugadores en 3 rounds, ");
Console.WriteLine("el que finalice con mas vida sera el ganador y avanzara a la proxima ronda. El que gane la final se sentara en el trono de hierro");
Console.WriteLine("Elige la cantidad de jugadores para el torneo (max: 128)");
int cantJugadores= Convert.ToInt32(Console.ReadLine());
if (cantJugadores < 8)
{
    cantJugadores= 8;
} 
else if (cantJugadores < 16)
{
    cantJugadores= 16;
}
else if (cantJugadores < 32)
{
    cantJugadores= 32;
}
else if (cantJugadores < 64)
{
    cantJugadores= 64;
}
else if (cantJugadores > 64)
{
    cantJugadores= 128;
}
int cantRondas= Convert.ToInt32(Math.Log2(cantJugadores));  //calculo cuantas rondas habra hasta obtener a un unico ganador
List<personaje> jugadores= new List<personaje>();
for (int i = 0; i < cantJugadores; i++)
{
    personaje nuevoJugador= new personaje();
    jugadores.Add(nuevoJugador);
}
Console.WriteLine("HORA DE PELEAR!!!");
combates enfrentador= new combates();
List<personaje> perdedores= new List<personaje>();
List<personaje> ganadores= new List<personaje>();
List<string> renglones= new List<string>();
string encabezadoCSV= "Nombre,Cant Partidas Ganadas,Apodo";
renglones.Add(encabezadoCSV);
string linea;
string lineaRondaAnterior;  //auxiliar para eliminar del csv las lineas de los jugadores que siguen sumando victorias
for (int i = 0; i < cantRondas; i++)
{
    for (int j = 0; j < cantJugadores; j+=2)
    {
        perdedores.Add(enfrentador.combatir(jugadores[j],jugadores[j+1]));
    }
    foreach (var jugador in perdedores)
    {
        jugadores.Remove(jugador);
    } 
    foreach (var jugador in jugadores)
    {
        linea= jugador.Informacion.Nombre + "," + (i+1) + "," + jugador.Informacion.Apodo;
        lineaRondaAnterior= jugador.Informacion.Nombre + "," + (i) + "," + jugador.Informacion.Apodo;
        renglones.Remove(lineaRondaAnterior);
        renglones.Add(linea);
    }
    cantJugadores= cantJugadores/2;
}
File.WriteAllLines(@"Lista de Ganadores", renglones);
Console.WriteLine("FELICITADIONES " + jugadores[0].Informacion.Nombre + "!!!!!!! HAS SIDO EL GANADOR DEL TORNEO, PROCEDE AHORA A SENTARTE EN");
    Console.WriteLine("EL TRONO DE HIERRO Y CONVIERTETE EN NUESTRO NUEVO LIDER");

