// See https://aka.ms/new-console-template for more information
public class personaje{
    private caracteristicas poder;
    private datos informacion;

    public personaje()
    {
        this.poder = new caracteristicas();
        this.informacion= new datos();
    }

    public caracteristicas Poder { get => poder; set => poder = value; }
    public datos Informacion { get => informacion; set => informacion = value; }
    public void mostrarDatos(){
        Console.WriteLine("||------Jugador: " + informacion.Nombre + "------||");
        Console.WriteLine("Apodo: " + informacion.Apodo);
        Console.WriteLine("Raza: " + informacion.Tipo);
        Console.WriteLine("Fecha de nacimiento: " + informacion.Fecha_Nac.ToShortDateString());
        Console.WriteLine("Edad: " + informacion.Edad);
    }

    public void mostrarCaracteristicas(){
        Console.WriteLine("Las caracteristicas de " + informacion.Nombre + "son:");
        Console.WriteLine("Nivel: " + poder.Nivel);
        Console.WriteLine("Fuerza: " + poder.Fuerza);
        Console.WriteLine("Velocidad: " + poder.Velocidad);
        Console.WriteLine("Destreza: " + poder.Destreza);
        Console.WriteLine("Armadura: " + poder.Armadura);
    }
}