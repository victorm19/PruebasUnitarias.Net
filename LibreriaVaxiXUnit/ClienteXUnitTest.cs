using System;
using Xunit;

namespace LibreriaVaxi;

public class ClienteXUnitTest
{
    private Cliente _cliente;

    public ClienteXUnitTest()
    {
        _cliente = new Cliente();
    }

    [Fact]
    public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
    {
        string resultadoExpected = "Victor Martinez";
        _cliente.CrearNombreCompleto("Victor", "Martinez");


        Assert.Equal(resultadoExpected, _cliente.ClienteNombre);
        Assert.Contains("Martinez", _cliente.ClienteNombre);

        Assert.StartsWith("Victor", _cliente.ClienteNombre);
        Assert.EndsWith("Martinez", _cliente.ClienteNombre);
    }

    [Fact]
    public void ClienteNombre_NoValues_ReturnNull()
    {
        Assert.Null(_cliente.ClienteNombre);
    }

    [Fact]
    public void DescuentoEvaluacion_DefaultClient_RetornaDescuentoIntervalo()
    {
        int descuento = _cliente.Descuento;
        Assert.InRange(descuento, 5, 24);
    }

    [Fact]
    public void CrearNombreCompleto_InputNombre_RetornaNotNull()
    {
        _cliente.CrearNombreCompleto("Vaxi", "");

        Assert.NotNull(_cliente.ClienteNombre);
        Assert.False(string.IsNullOrEmpty(_cliente.ClienteNombre));
    }

    [Fact]
    public void ClienteNombre_InputNombreEnBlanco_ThrowException()
    {
        var exceptionDetalle = Assert.Throws<ArgumentException>(() => _cliente.CrearNombreCompleto("", "Martinez"));

        Assert.Equal("El nombre esta en blanco", exceptionDetalle.Message);

        Assert.Throws<ArgumentException>(() => _cliente.CrearNombreCompleto("", "Martinez"));
    }

    [Fact]
    public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
    {
        _cliente.OrderTotal = 150;

        var resultado = _cliente.GetClienteDetalle();

        Assert.IsType<ClienteBasico>(resultado);
    }

    [Fact]
    public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClientePremium()
    {
        _cliente.OrderTotal = 700;

        var resultado = _cliente.GetClienteDetalle();

        Assert.IsType<ClientePremium>(resultado);
    }
}

