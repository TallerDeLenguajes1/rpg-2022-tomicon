// See https://aka.ms/new-console-template for more information
public class caracteristicas{
    private int velocidad;// 1 a 10
    private int destreza; //1 a 5
    private int fuerza;//1 a 10
    private int nivel; //1 a 10
    private int armadura; //1 a 10

    public caracteristicas()
    {
        Random r= new Random();
        velocidad= r.Next(1, 11);
        destreza= r.Next(1,6);
        fuerza= r.Next(1, 11);
        nivel= r.Next(1, 11);
        armadura= r.Next(1, 11);
    }

    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
}