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
        string[] nombres= {"Jesse","Nurten","Hildegart","Mirja","Elfi","Ingeburg","Annegrete","Lieselotte","Kiyasi","Kete","Altug","Miray","Bayan","Nalan","Beatrice","Aalis"};
        string[] apellido= {"Gregoire","Leduc","Roussel","Bodin","Trentini","Combi","Ossani","Giunti","Fritsch","Buchholz","Oderwald","Stroh"};
        string[] apodos= {"Protesian","Nessundorma","Demonologist","Elessar","undomiel","Earendil","Gilthoniel","Shadowhunter"};
        string[] apodos2= {"Shruikan","Argetlam","Arya","Elva","Sloan","Brugh","Shadow killer","The great"};
        string[] tipos= {"elfo","hombre","brujo","orco","troll","enano","animal encantado"};
        double saludInicial = 10000;
        Random r= new Random();
        nombre= nombres[r.Next(0,16)] + " " + apellido[r.Next(0,12)];
        salud = saludInicial;
        apodo = apodos[r.Next(0,8)] + " " + apodos2[r.Next(0,8)];
        tipo =  tipos[r.Next(0,7)];
        fecha_Nac = new DateTime(r.Next(1722, 2012), r.Next(1, 13), r.Next(1, 31));
        edad = calcularEdad(fecha_Nac);
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime Fecha_Nac { get => fecha_Nac; set => fecha_Nac = value; }
    public int Edad { get => edad; set => edad = value; }
    public double Salud { get => salud; set => salud = value; }
    public string Tipo { get => tipo; set => tipo = value; }
}


