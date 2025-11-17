using FluentAssertions;

namespace WordWrapTDD;

public class WordWrapTest
{
    [Fact]
    public void Dado_StringPezYNumeroDeColumnas5_Debe_RetornarCadenaSinCortar()
    {
        var wordWrap = new WordWrap();

        var resultado = wordWrap.AjustarTexto("Pez", 5);

        resultado.Should().Be("Pez");

    }

    [Theory]
    [InlineData("Pez", 5)]
    [InlineData("Perro", 10)]
    public void Dado_StringDeNCantidadDeCaracteresYCantidadDeColumnasMayorQueLongitud_Debe_RetornarCadenaCompleta(string texto, int columnas)
    {
        var wordWrap = new WordWrap();

        var resultado = wordWrap.AjustarTexto(texto, columnas);

        resultado.Should().Be(texto); 
    }
}

public class WordWrap
{
    public string AjustarTexto(string texto, int columnas)
    {
        return texto;
    }
}