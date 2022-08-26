using NUnit.Framework;

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

        Assert.That(_cliente.ClienteNombre, Is.EqualTo(resultadoExpected));
        Assert.AreEqual(_cliente.ClienteNombre, resultadoExpected);
        Assert.That(_cliente.ClienteNombre, Does.Contain("Martinez"));
        Assert.That(_cliente.ClienteNombre, Does.Contain("martinez").IgnoreCase); //Ignora mayusculas y minusculas
        Assert.That(_cliente.ClienteNombre, Does.StartWith("Victor"));
        Assert.That(_cliente.ClienteNombre, Does.EndWith("Martinez"));
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
}

