using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LibreriaVaxi;

public class OperacionXUnitTest
{
    [Fact]
    public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
    {
        //Arrange
        int numero1 = 10;
        int numero2 = 2;

        //Act
        int resultado = Operacion.SumarNumeros(numero1, numero2);

        //Assert
        Assert.Equal(12, resultado);
    }

    [Theory]
    [InlineData(3, false)]
    [InlineData(5, false)]
    public void EsValorPar_InputNumeroInpar_RetornaFalse(int numeroInpar, bool expectedResult)
    {
        var resultado = Operacion.EsValorPar(numeroInpar);
        
        Assert.Equal(expectedResult, resultado);    
    }

    [Theory]
    [InlineData(4)]
    [InlineData(6)]
    [InlineData(20)]
    public void EsValorPar_InputNumeroPar_RetornaTrue(int numeroPar)
    {
        var resultado = Operacion.EsValorPar(numeroPar);

        Assert.True(resultado);
    }

    [Theory]
    [InlineData(2.2, 1.2)] // => 3.4
    [InlineData(2.23, 1.24)] // => 3.47
    public void SumarDecimal_InputDosNumeros_GetValorCorrecto(double decimal1, double decimal2)
    {
        //Act
        double resultado = Operacion.SumarDecimal(decimal1, decimal2);

        //Assert
        Assert.Equal(3.4, resultado, 0);
    }

    [Fact]
    public void GetListaNumeroImpares_InputMinimoMaximoIntervalos_RetornaListaNumerosImpares()
    {
        Operacion op = new();

        List<int> numerosImparesEsperados = new() { 5, 7, 9 };

        var resultado = op.GetListaNumeroImpares(5, 10);

        Assert.Equal(numerosImparesEsperados, resultado);
        Assert.Contains(5, resultado);
        Assert.NotEmpty(resultado);
        Assert.Equal(3, resultado.Count);
        Assert.DoesNotContain(100, resultado);
        Assert.Equal(resultado.OrderBy(x => x), resultado);
    }
}

