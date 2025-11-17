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
}

public class WordWrap
{
    public string AjustarTexto(string pez, int i)
    {
        throw new NotImplementedException();
    }
}