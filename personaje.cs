// See https://aka.ms/new-console-template for more information
public class personaje{
    private caracteristicas poder;
    private datos informacion;

    public personaje()
    {
    }

    public caracteristicas Poder { get => poder; set => poder = value; }
    public datos Informacion { get => informacion; set => informacion = value; }

    public int calcularEdad(DateTime nacimiento){
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
    public void cargarDatos(){
        string[] nombres= {"Jesse","Nurten","Hildegart","Mirja","Elfi","Ingeburg","Annegrete","Lieselotte","Kiyasi","Kete","Altug","Miray","Bayan","Nalan","Beatrice","Aalis"};
        string[] apellido= {"Gregoire","Leduc","Roussel","Bodin","Trentini","Combi","Ossani","Giunti","Fritsch","Buchholz","Oderwald","Stroh"};
        string[] apodos= {"Protesian","Nessundorma","Demonologist","Elessar","undomiel","Earendil","Gilthoniel","Shadowhunter"};
        string[] tipos= {"elfo","hombre","brujo","orco","troll","enano","animal encantado"};
        int saludInicial = 100;
        Random r= new Random();
        Informacion.Nombre= nombres[r.Next(0,16)] + " " + apellido[r.Next(0,12)];
        Informacion.Salud = saludInicial;
        Informacion.Apodo = apodos[r.Next(0,8)] + " " + apodos[r.Next(0,8)];
        Informacion.Tipo =  tipos[r.Next(0,7)];
        Informacion.Fecha_Nac = new DateTime(r.Next(1722, 2012), r.Next(1, 13), r.Next(1, 31));
        Informacion.Edad = calcularEdad(Informacion.Fecha_Nac);
    }
}