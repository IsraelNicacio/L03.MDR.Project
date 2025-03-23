using System.Globalization;
using System.Text.RegularExpressions;

namespace MDR.Core.DomainObject;

public class DomainValidation
{
    public static void ValidarSeNulo(object obj, string message)
    {
        if (obj is null)
            new DomainException(message);
    }

    public static void ValidarSeIqual(object obj, string objCompare, string message)
    {
        if (!obj.Equals(objCompare))
            new DomainException(message);
    }

    public static void ValidarSeDiferente(object obj, string objCompare, string message)
    {
        if (obj.Equals(objCompare))
            new DomainException(message);
    }

    public static void ValidarSeNulo(string value, string message)
    {
        if (string.IsNullOrWhiteSpace(value))
            new DomainException(message);
    }

    public static void ValidarSeIqual(string value, string valueCompare, string message)
    {
        ValidarSeNulo(value, "Valor Não Pode ser Nulo");

        if (CultureInfo.CreateSpecificCulture("pt-BR")
            .CompareInfo
            .Compare(value, valueCompare) != 0)
            new DomainException(message);
    }

    public static void ValidarSeDiferente(string value, string valueCompare, string message)
    {
        ValidarSeNulo(value, "Valor Não Pode ser Nulo");

        if (CultureInfo.CreateSpecificCulture("pt-BR")
            .CompareInfo
            .Compare(value, valueCompare) == 0)
            new DomainException(message);
    }

    public static void ValidarCaracteres(string value, int minimo, int maximo, string message)
    {
        ValidarSeNulo(value, "Valor Não Pode ser Nulo");

        if (value.Length < minimo && value.Length > maximo)
            new DomainException(message);
    }

    public static void ValidarCaracteres(string value, int maximo, string message)
    {
        ValidarSeNulo(value, "Valor Não Pode ser Nulo");

        if (value.Length > maximo)
            new DomainException(message);
    }

    public static void ValidarExpressaoRegular(string value, string pattern, string message)
    {
        ValidarSeNulo(value, "Valor Não Pode ser Nulo");

        if (Regex.IsMatch(value, pattern))
            new DomainException(message);
    }

    public static void ValidarMinimoMaximo(decimal value, decimal minimo, decimal maximo, string message)
    {
        if (value < minimo && value > maximo)
            new DomainException(message);
    }

    public static void ValidarMaximo(decimal value, decimal maximo, string message)
    {
        if (value > maximo)
            new DomainException(message);
    }

    public static void ValidarSeMenorIqualMinimo(decimal value, decimal min, string message)
    {
        if (value <= min)
            throw new DomainException(message);
    }

    public static void ValidarMinimoMaximo(int value, int minimo, int maximo, string message)
    {
        if (value < minimo && value > maximo)
            new DomainException(message);
    }

    public static void ValidarMaximo(int value, int maximo, string message)
    {
        if (value > maximo)
            new DomainException(message);
    }

    public static void ValidarSeMenorIqualMinimo(int value, int min, string message)
    {
        if (value <= min)
            throw new DomainException(message);
    }

    public static void ValidarSeFalso(bool value, string message)
    {
        if (value)
            throw new DomainException(message);
    }

    public static void ValidarSeVerdadeiro(bool value, string message)
    {
        if (!value)
            throw new DomainException(message);
    }
}