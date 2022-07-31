// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Net;
Console.WriteLine("BIENVENIDO A \"THE IRON THRONE TOURNAMENT\"!!!!!! TE CREES CAPAZ DE ALCANZAR LA GLORIA DEL TRONO DE HIERRO??\n");
Console.WriteLine("La dinamica es muy simple. Se hara un torneo entre al menos 8 jugadores. En cada ronda se enfrentaran dos jugadores en 3 rounds, ");
Console.WriteLine("el que finalice con mas vida sera el ganador y avanzara a la proxima ronda. El que gane la final se sentara en el trono de hierro");
Console.WriteLine("Desea cargar nuevos personajes o jugar con los que se encuentran guardados? En caso de que no haya jugadores guardados, se pasara directamente a la carga de nuevos personajes");
Console.WriteLine("(Jugar con los guardados= 1, Cargar nuevos = cualquier otra tecla)");
List<personaje> jugadores= new List<personaje>();
int cargarPersonajes= Convert.ToInt32(Console.ReadLine());
int cantJugadores;
if (cargarPersonajes == 1 && File.Exists("jugadores.json"))
{
    jugadores = JsonSerializer.Deserialize<List<personaje>>(File.ReadAllText("jugadores.json"));
    cantJugadores= jugadores.Count();
} else
{
    Console.WriteLine("Elige la cantidad de jugadores para el torneo (max: 128)");
    cantJugadores= Convert.ToInt32(Console.ReadLine());
        if (cantJugadores < 9)
    {
        cantJugadores= 8;
    } 
    else if (cantJugadores < 17)
    {
        cantJugadores= 16;
    }
    else if (cantJugadores < 33)
    {
        cantJugadores= 32;
    }
    else if (cantJugadores < 65)
    {
        cantJugadores= 64;
    }
    else if (cantJugadores > 64)
    {
        cantJugadores= 128;
    }
    for (int i = 0; i < cantJugadores; i++)
    {
        personaje nuevoJugador= new personaje();
        jugadores.Add(nuevoJugador);
    }
    string Json_jugadores = JsonSerializer.Serialize(jugadores);
    File.WriteAllText("jugadores.json",Json_jugadores);
}
var url = $"https://api.disneyapi.dev/characters";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";
List<string> Arenas = new List<string>();
Console.WriteLine("HORA DE PELEAR!!!");
int cantRondas= Convert.ToInt32(Math.Log2(cantJugadores));  //calculo cuantas rondas habra hasta obtener a un unico ganador
combates enfrentador= new combates();
List<personaje> perdedores= new List<personaje>();    
List<personaje> ganadores= new List<personaje>();
List<string> renglones= new List<string>();    //Lista para agregar en el csv
string encabezadoCSV= "Nombre,Cant Partidas Ganadas,Apodo";
renglones.Add(encabezadoCSV);
string linea;
string lineaRondaAnterior;  //auxiliar para eliminar del csv las lineas de los jugadores que siguen sumando victorias
using (WebResponse response = request.GetResponse())
        {
            using (Stream strReader = response.GetResponseStream())
            {
                if (strReader == null) return;
                using (StreamReader objReader = new StreamReader(strReader))
                {
                    string responseBody = objReader.ReadToEnd();
                    Root amigos = JsonSerializer.Deserialize<Root>(responseBody);
                    foreach (var item in amigos.data)
                    {
                        foreach (var dato in item.parkAttractions)
                        {
                            Arenas.Add(dato);
                        }
                    }
                }
            }
        }
Random r = new Random();
for (int i = 0; i < cantRondas; i++)
{
    Console.WriteLine("\nESTA BATALLA SE DISPUTARÁ EN LA ARENA " + Arenas[r.Next(0, Arenas.Count() - 1)]);
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

