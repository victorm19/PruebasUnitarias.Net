using Moq;
using Xunit;

namespace LibreriaVaxi;

public class CuentaBancariaXUintTest
{

    [Fact]
    public void Deposito_InputMonto100LoggerFake_ReturnsTrue()
    {
        var cuentaBancaria = new CuentaBancaria(new LoggerFake());
        var resultado = cuentaBancaria.Deposito(100);

        Assert.True(resultado);
        Assert.Equal(100, cuentaBancaria.GetBalance());
    }

    [Fact]
    public void Deposito_InputMonto100Mocking_ReturnsTrue()
    {
        var mocking = new Mock<ILoggerGeneral>();

        var cuentaBancaria = new CuentaBancaria(mocking.Object);
        var resultado = cuentaBancaria.Deposito(100);

        Assert.True(resultado);
        Assert.Equal(100, cuentaBancaria.GetBalance());
    }

    [Theory]
    [InlineData(200, 100)]
    [InlineData(200, 150)]
    public void Retiro_Retiro100ConBalance200_ReturnsTrue(int balance, int retiro)
    {
        var loggerMock = new Mock<ILoggerGeneral>();
        loggerMock.Setup(s => s.LogDatabase(It.IsAny<string>())).Returns(true);
        loggerMock.Setup(s => s.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true);

        var cuentaBancaria = new CuentaBancaria(loggerMock.Object);
        cuentaBancaria.Deposito(balance);

        var resultado = cuentaBancaria.Retiro(retiro);

        Assert.True(resultado);
    }

    [Theory]
    [InlineData(200, 300)]
    public void Retiro_Retiro300ConBalance200_ReturnsFalse(int balance, int retiro)
    {
        var loggerMock = new Mock<ILoggerGeneral>();
        //loggerMock.Setup(s => s.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false);
        loggerMock.Setup(s => s.LogBalanceDespuesRetiro(It.IsInRange<int>(int.MinValue, -1, Range.Inclusive))).Returns(false);

        var cuentaBancaria = new CuentaBancaria(loggerMock.Object);
        cuentaBancaria.Deposito(balance);

        var resultado = cuentaBancaria.Retiro(retiro);

        Assert.False(resultado);
    }

    [Fact]
    public void CuentaBancariaLoggerGeneral_LogMocking_ReturnsTrue()
    {
        var loggerGeneralMock = new Mock<ILoggerGeneral>();
        var textoPrueba = "hola mundo";

        loggerGeneralMock.Setup(u => u.MessageConReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());

        var resultado = loggerGeneralMock.Object.MessageConReturnString("HOLA MUNDO");

        Assert.Equal(textoPrueba, resultado);
    }

    [Fact]
    public void CuentaBancariaLoggerGeneral_LogMockingOutPUT_ReturnsTrue()
    {
        var loggerGeneralMock = new Mock<ILoggerGeneral>();
        var textoPrueba = "Hola mundo";

        loggerGeneralMock.Setup(x => x.MessageConOutParametroReturnBoolean(It.IsAny<string>(), out textoPrueba)).Returns(true);

        var resultado = loggerGeneralMock.Object.MessageConOutParametroReturnBoolean("mundo", out string parameterOut);

        Assert.True(resultado);
        Assert.Equal(textoPrueba, parameterOut);
    }

    [Fact]
    public void CuentaBancariaLoggerGeneral_LogMockingObjectRef_ReturnsTrue()
    {
        var loggerGeneralMock = new Mock<ILoggerGeneral>();
        Cliente cliente = new();
        Cliente clienteNoUsado = new();

        loggerGeneralMock.Setup(x => x.MessageConObjetoReferenciaReturnBoolean(ref cliente)).Returns(true);

        var resultadoTrue = loggerGeneralMock.Object.MessageConObjetoReferenciaReturnBoolean(ref cliente);
        var resultadoFalse = loggerGeneralMock.Object.MessageConObjetoReferenciaReturnBoolean(ref clienteNoUsado);

        Assert.True(resultadoTrue);
        Assert.False(resultadoFalse);
    }

    [Fact]
    public void CuentaBancariaLoggerGeneral_LogMockingPropiedadPrioridadTipo_ReturnsTrue()
    {
        var loggerGeneralMock = new Mock<ILoggerGeneral>();

        loggerGeneralMock.Setup(x => x.TipoLogger).Returns("Warning");
        loggerGeneralMock.Setup(x => x.PrioridadLogger).Returns(100);


        Assert.Equal("Warning", loggerGeneralMock.Object.TipoLogger);
        Assert.Equal(100, loggerGeneralMock.Object.PrioridadLogger);


        //CALLBACKS
        string textoTemporal = "vict";
        loggerGeneralMock.Setup(x => x.LogDatabase(It.IsAny<string>()))
            .Returns(true)
            .Callback<string>(parametro => textoTemporal += parametro);

        loggerGeneralMock.Object.LogDatabase("or");

        Assert.Equal("victor", textoTemporal);
    }

    [Fact]
    public void CuentaBancariaLogger_VerifyEjemplo()
    {
        var loggerGeneralMock = new Mock<ILoggerGeneral>();

        CuentaBancaria cuentaBancaria = new(loggerGeneralMock.Object);
        cuentaBancaria.Deposito(100);

        Assert.Equal(100, cuentaBancaria.GetBalance());

        //Verifica cuantas veces el mock esta llamando al metodo message

        loggerGeneralMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(3));
        loggerGeneralMock.Verify(x => x.Message("Verify"), Times.AtLeastOnce);
        loggerGeneralMock.VerifySet(x => x.PrioridadLogger = 100, Times.Once);
        loggerGeneralMock.VerifyGet(x => x.PrioridadLogger, Times.Once);
    }
}
