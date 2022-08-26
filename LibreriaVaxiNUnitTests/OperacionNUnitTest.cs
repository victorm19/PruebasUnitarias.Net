using NUnit.Framework;
using System.Collections.Generic;

namespace LibreriaVaxi;

[TestFixture]
public class OperacionNUnitTest
{
    [Test]
    public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
    {
        //Arrange
        int numero1 = 10;
        int numero2 = 2;

        //Act
        int resultado = Operacion.SumarNumeros(numero1, numero2);

        //Assert
        Assert.AreEqual(12, resultado);
    }

    [Test]
    [TestCase(3, ExpectedResult = false)]
    [TestCase(5, ExpectedResult = false)]
    public bool EsValorPar_InputNumeroInpar_RetornaFalse(int numeroInpar)
    {
        return Operacion.EsValorPar(numeroInpar);
    }

    [Test]
    [TestCase(4)]
    [TestCase(6)]
    [TestCase(20)]
    public void EsValorPar_InputNumeroPar_RetornaTrue(int numeroPar)
    {
        var resultado = Operacion.EsValorPar(numeroPar);

        Assert.IsTrue(resultado);
        Assert.That(resultado, Is.True);
    }

    [Test]
    [TestCase(2.2, 1.2)] // => 3.4
    [TestCase(2.23, 1.24)] // => 3.47
    public void SumarDecimal_InputDosNumeros_GetValorCorrecto(double decimal1, double decimal2)
    {
        //Act
        double resultado = Operacion.SumarDecimal(decimal1, decimal2);

        //Assert
        Assert.AreEqual(3.4, resultado, 0.1);
    }

    [Test]
    public void GetListaNumeroImpares_InputMinimoMaximoIntervalos_RetornaListaNumerosImpares()
    {
        Operacion op = new();

        List<int> numerosImparesEsperados = new() { 5, 7, 9 };

        var resultado = op.GetListaNumeroImpares(5, 10);

        Assert.That(resultado, Is.EquivalentTo(numerosImparesEsperados));
        Assert.AreEqual(numerosImparesEsperados, resultado);
        Assert.That(resultado, Does.Contain(5));
        Assert.Contains(5, resultado);
        Assert.That(resultado, Is.Not.Empty);
        Assert.That(resultado.Count, Is.EqualTo(3));
        Assert.That(resultado, Has.No.Member(100));
        Assert.That(resultado, Is.Ordered);
        Assert.That(resultado, Is.Unique);
    }
}

