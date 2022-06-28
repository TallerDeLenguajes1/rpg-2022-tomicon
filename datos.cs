// See https://aka.ms/new-console-template for more information
public class datos {
    private string tipo;
    private string nombre;
    private string apodo;
    private DateTime fecha_Nac;
    private int edad; //entre 0 a 300
    private double salud;//100

    public int calcularEdad(DateTime nacimiento)
    {
        int edad = DateTime.Now.Year - nacimiento.Year;
        if (DateTime.Now.Month < nacimiento.Year)
        {
            edad -= 1;
        }
        if (DateTime.Now.Month == nacimiento.Year && DateTime.Now.Day < nacimiento.Day)
        {
            edad -= 1;
        }
        return edad;
    }
    public datos()
    {
        string[] nombres= {"JESSE","NURTEN","HILDEGART","MIRJA","ELFI","INGEBURG","ANNEGRETE","LIESELOTTE","KIYASI","KETE","ALTUG","MIRAY","BAYAN","NALAN","BEATRICE","AALIS"};
        string[] apellido= {"GREGOIRE","LEDUC","ROUSSEL","BODIN","TRENTINI","COMBI","OSSANI","GIUNTI","FRITSCH","BUCHHOLZ","ODERWALD","STROH"};
        string[] apodos= {"PROTESIAN","NESSUNDORMA","DEMONOLOGIST","ELESSAR","UNDOMIEL","EARENDIL","GILTHONIEL","SHADOWHUNTER"};
        string[] apodos2= {"SHRUIKAN","ARGETLAM","ARYA","ELVA","SLOAN","BRUGH","SHADOW KILLER","THE GREAT"};
        string[] tipos= {"elfo","hombre","brujo","orco","troll","enano","animal encantado"};
        double saludInicial = 10000;
        Random r= new Random();
        nombre= nombres[r.Next(0,16)] + " " + apellido[r.Next(0,12)];
        salud = saludInicial;
        apodo = apodos[r.Next(0,8)] + " " + apodos2[r.Next(0,8)];
        tipo =  tipos[r.Next(0,7)];
        int anio= r.Next(1722, 2012);
        int mes= r.Next(1, 13);
        int dia;
        if (anio == 1 || anio == 3 || anio == 5 || anio == 7 || anio == 8 || anio == 10 || anio == 12)
        {
            dia = r.Next(1, 32);   
        } else if (anio == 2)
        {
            dia = r.Next(1,29);
        } else
        {
            dia = r.Next(1,31);
        }
        fecha_Nac = new DateTime(anio, mes , dia);
        edad = calcularEdad(fecha_Nac);
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime Fecha_Nac { get => fecha_Nac; set => fecha_Nac = value; }
    public int Edad { get => edad; set => edad = value; }
    public double Salud { get => salud; set => salud = value; }
    public string Tipo { get => tipo; set => tipo = value; }
}


