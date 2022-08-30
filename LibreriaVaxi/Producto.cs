namespace LibreriaVaxi;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }

    public double GetPrecio(Cliente cliente) 
        => cliente.IsPremium ? Precio * .8 : Precio;
    
    public double GetPrecio(ICliente cliente) 
        => cliente.IsPremium ? Precio * .8 : Precio;
 
}
