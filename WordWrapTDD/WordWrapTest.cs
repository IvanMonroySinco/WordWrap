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
    public void Dado_StringDeNCantidadDeCaracteresYCantidadDeColumnasMayorOIgualQueLongitud_Debe_RetornarCadenaCompleta(string texto, int columnas)
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