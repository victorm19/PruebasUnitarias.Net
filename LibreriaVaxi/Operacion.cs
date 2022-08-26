namespace LibreriaVaxi;

public class Operacion
{
    public List<int> NumerosImpares = new();

    public static int SumarNumeros(int numero1, int numero2) => numero1 + numero2;

    public static bool EsValorPar(int numero) => (numero % 2) == 0;

    public static double SumarDecimal(double decimal1, double decimal2) => decimal1 + decimal2;

    public List<int> GetListaNumeroImpares(int intervaloMinimo, int intervaloMaximo)
    {
        NumerosImpares.Clear();

        for (int i = intervaloMinimo; i <= intervaloMaximo; i++)
        {
            if(i % 2 != 0)
                NumerosImpares.Add(i);
        }

        return NumerosImpares;
    }
}