using NUnit.Framework;
using System;

namespace LibreriaVaxi;

[TestFixture]
public class ClienteNUnitTest
{
    private Cliente _cliente;

    [SetUp]
    public void SetUp()
    {
        _cliente = new Cliente();
    }

    [Test]
    public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
    {
        string resultadoExpected = "Victor Martinez";
        _cliente.CrearNombreCompleto("Victor", "Martinez");

        Assert.Multiple(() =>
        {
            Assert.That(_cliente.ClienteNombre, Is.EqualTo(resultadoExpected));
            Assert.AreEqual(_cliente.ClienteNombre, resultadoExpected);
            Assert.That(_cliente.ClienteNombre, Does.Contain("Martinez"));
            Assert.That(_cliente.ClienteNombre, Does.Contain("martinez").IgnoreCase); //Ignora mayusculas y minusculas
            Assert.That(_cliente.ClienteNombre, Does.StartWith("Victor"));
            Assert.That(_cliente.ClienteNombre, Does.EndWith("Martinez"));
        });
    }

    [Test]
    public void ClienteNombre_NoValues_ReturnNull()
    {
        Assert.IsNull(_cliente.ClienteNombre);
    }

    [Test]
    public void DescuentoEvaluacion_DefaultClient_RetornaDescuentoIntervalo()
    {
        int descuento = _cliente.Descuento;
        Assert.That(descuento, Is.InRange(5, 24));
    }

    [Test]
    public void CrearNombreCompleto_InputNombre_RetornaNotNull()
    {
        _cliente.CrearNombreCompleto("Vaxi", "");

        Assert.IsNotNull(_cliente.ClienteNombre);
        Assert.IsFalse(string.IsNullOrEmpty(_cliente.ClienteNombre));
    }

    [Test]
    public void ClienteNombre_InputNombreEnBlanco_ThrowException()
    {
        var exceptionDetalle = Assert.Throws<ArgumentException>(() => _cliente.CrearNombreCompleto("", "Martinez"));

        Assert.AreEqual("El nombre esta en blanco", exceptionDetalle.Message);
        Assert.That(() => 
            _cliente.CrearNombreCompleto("", "Martinez"), Throws.ArgumentException.With.Message.EqualTo("El nombre esta en blanco"));

        Assert.Throws<ArgumentException>(() => _cliente.CrearNombreCompleto("", "Martinez"));
        Assert.That(() =>
            _cliente.CrearNombreCompleto("", "Martinez"), Throws.ArgumentException);
    }

    [Test]
    public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
    {
        _cliente.OrderTotal = 150;

        var resultado = _cliente.GetClienteDetalle();

        Assert.That(resultado, Is.TypeOf<ClienteBasico>());
    }

    [Test]
    public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClientePremium()
    {
        _cliente.OrderTotal = 700;

        var resultado = _cliente.GetClienteDetalle();

        Assert.That(resultado, Is.TypeOf<ClientePremium>());
    }
}

