using FluentAssertions;

namespace WordWrapTDD;

public class WordWrapTest
{
    [Theory]
    [InlineData("Pez", 5)]
    [InlineData("Perro", 10)]
    [InlineData("Gato", 6)]
    [InlineData("Gallina", 8)]
    [InlineData("Cadena", 6)]
    [InlineData("Hipopotamo", 10)]
    public void Dado_StringDeNCantidadDeCaracteresYCantidadDeColumnasMayorOIgualQueLongitud_Debe_RetornarCadenaCompleta(
        string texto, int columnas)
    {
        var wordWrap = new WordWrap();

        var resultado = wordWrap.AjustarTexto(texto, columnas);

        resultado.Should().Be(texto);
    }

    [Fact]
    public void Dado_TextoPerroYColumnas3_Debe_RetornarTextoConSaltoDeLineaDespuesDe3PrimerosCaracteres()
    {
        var wordWrap = new WordWrap();

        var resultado = wordWrap.AjustarTexto("Perro", 3);

        resultado.Should().Be("Per\nro");
    }

    [Fact]
    public void Dado_TextoComputadoraYColumnas5_Debe_RetornarTextoConSaltoDeLineaDespuesDe5PrimerosCaracteres()
    {
        var wordWrap = new WordWrap();

        var resultado = wordWrap.AjustarTexto("Computadora", 5);

        resultado.Should().Be("Compu\ntadora");
    }

    [Fact]
    public void Dado_TextoIrremediableYColumnas8_Debe_RetornarTextoConSaltoDeLineaDespuesDe8PrimerosCaracteres()
    {
        var wordWrap = new WordWrap();

        var resultado = wordWrap.AjustarTexto("Irremediable", 8);

        resultado.Should().Be("Irremedi\nable");
    }

    [Fact]
    public void Dado_TextoHolaMundoConEspacioIntermedioYColumnas6_Debe_RetornarSaltoDeLineaEnElEspacio()
    {
        var wordWrap = new WordWrap();

        var resultado = wordWrap.AjustarTexto("Hola Mundo", 8);

        resultado.Should().Be("Hola\nMundo");
    }
}

public class WordWrap
{
    private const string SaltoDeLinea = "\n";

    public string AjustarTexto(string texto, int columnas)
    {
        if (texto.IndexOf(" ", StringComparison.Ordinal) > 0)
        {
            return texto.Replace(" ", "\n");
        }
        
        if (texto.Length <= columnas)
            return texto;

        return texto.Substring(0, columnas) + SaltoDeLinea + texto.Substring(columnas);
        
    }
}