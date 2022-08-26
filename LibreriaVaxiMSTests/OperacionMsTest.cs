using LibreriaVaxi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibreriaVaxiMSTests;

[TestClass]
public class OperacionMsTest
{
    [TestMethod]
    public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
    {
        //Arrange
        Operacion op = new();
        int numero1 = 10;
        int numero2 = 2;

        //Act
        int resultado = Operacion.SumarNumeros(numero1, numero2);

        //Assert
        Assert.AreEqual(12, resultado);
    }
}
