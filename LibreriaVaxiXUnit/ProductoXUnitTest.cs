using Moq;
using Xunit;

namespace LibreriaVaxi;

public class ProductoXUnitFact
{
    [Fact]
    public void GetPrecio_PremiumCliente_ReturnsPrecio80()
    {
        var producto = new Producto { Precio = 50 };

        var resultado = producto.GetPrecio(new Cliente { IsPremium = true });

        Assert.Equal(40, resultado);
    }

    [Fact]
    public void GetPrecio_PremiumClienteMoq_ReturnsPrecio80()
    {
        var producto = new Producto { Precio = 50 };

        var cliente = new Mock<ICliente>();
        cliente.Setup(s => s.IsPremium).Returns(true);

        var resultado = producto.GetPrecio(cliente.Object);

        Assert.Equal(40, resultado);
    }
}
