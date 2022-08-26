namespace LibreriaVaxi;

public class Cliente
{
    public string ClienteNombre { get; set; }
    public int Descuento = 10;

    public string CrearNombreCompleto(string nombre, string apellido)
    {
        Descuento = 30;
        ClienteNombre = $"{nombre} {apellido}";

        return ClienteNombre;
    }
}

