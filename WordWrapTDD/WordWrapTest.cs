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
    public void Dado_TextoComputadorYColumnas5_Debe_RetornarTextoConSaltoDeLineaDespuesDe5PrimerosCaracteres()
    {
        var wordWrap = new WordWrap();

        var resultado = wordWrap.AjustarTexto("Computador", 5);

        resultado.Should().Be("Compu\ntador");
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
    
    [Fact]
    public void Dado_TextoHolaMundoDesarrolladoresConEspaciosIntermediosYColumnas15_Debe_RetornarSaltoDeLineaEnElEspacio()
    {
        var wordWrap = new WordWrap();

        var resultado = wordWrap.AjustarTexto("Hola Mundo Desarrolladores", 15);

        resultado.Should().Be("Hola\nMundo\nDesarrolladores");
    }

    [Fact]
    public void Dado_TextoConEspacioInicialOFinal_NoDebe_RetornarCadenaEmpezandoConSaltoDeLinea()
    {
        var wordWrap = new WordWrap();

        var resultado = wordWrap.AjustarTexto(" Buenos Dias", 15);

        resultado.Should().Be("Buenos\nDias");
    }
    [Fact]
    public void Dado_TextoLargoCon4Columnas_Debe_RetornarMultimplesSaltosDeLineaCada4Caracteres()
    {
        var wordWrap = new WordWrap();

        var resultado = wordWrap.AjustarTexto("TextoLargoConPocasColumnas", 4);

        resultado.Should().Be("Text\noLar\ngoCo\nnPoc\nasCo\nlumn\nas");
    }
}

public class WordWrap
{
    private const string SaltoDeLinea = "\n";

    public string AjustarTexto(string texto, int columnas)
    {
        texto = texto.Trim();
        
        
        if (texto.IndexOf(" ", StringComparison.Ordinal) >= 0)
            return texto.Replace(" ", "\n");
        
        if (texto.Length <= columnas)
            return texto;
        
        return texto[..columnas] + SaltoDeLinea + AjustarTexto(texto[columnas..], columnas) ;
    }
}