// See https://aka.ms/new-console-template for more information
public partial class datos {
    private int tipo;
    private string nombre;
    private string apodo;
    private DateTime fecha_Nac;
    private int edad; //entre 0 a 300
    private int salud;//100

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime Fecha_Nac { get => fecha_Nac; set => fecha_Nac = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Salud { get => salud; set => salud = value; }
    public int Tipo { get => tipo; set => tipo = value; }
}


