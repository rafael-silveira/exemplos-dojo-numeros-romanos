using FluentAssertions;
using NumerosRomanosLibrary;
using Xunit;

namespace NumerosRomanosUnitTestsLibrary
{
    public class NumerosRomanosParserUnitTests
    {
        [Theory]
        [InlineData("I")]
        [InlineData("II")]
        [InlineData("III")]
        [InlineData("IV")]
        [InlineData("VIII")]
        [InlineData("IX")]
        [InlineData("XX")]
        [InlineData("XL")]
        [InlineData("LXX")]
        [InlineData("XC")]
        public void IsValid_NumerosRomanosValidos_RetornoTrue(string numeroRomano)
        {
            var subject = new NumerosRomanosParser();
            var result = subject.IsValid(numeroRomano);
            result.Should().BeTrue();

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("i")]
        [InlineData("VIIII")]
        [InlineData("IIII")]
        [InlineData("XXC")]
        [InlineData("XXL")]
        [InlineData("CCMCL")]
        public void IsValid_NumerosRomanosInvalidos_RetornoFalse(string numeroRomano)
        {
            var subject = new NumerosRomanosParser();
            var result = subject.IsValid(numeroRomano);
            result.Should().BeFalse();
        }


        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("V", 5)]
        [InlineData("VII", 7)]
        [InlineData("IX", 9)]
        [InlineData("X", 10)]
        [InlineData("XX", 20)]
        [InlineData("XL", 40)]
        [InlineData("L", 50)]
        [InlineData("LX", 60)]
        [InlineData("XC", 90)]
        [InlineData("C", 100)]
        [InlineData("CD", 400)]
        [InlineData("DCC", 700)]
        [InlineData("M", 1000)]
        [InlineData("MDCXXVII", 1627)]
        [InlineData("MCMLXXVIII", 1978)]
        [InlineData("MMXXI", 2021)]
        public void Parse_NumeroRomanoValido_NumeroObtido(string numeroRomano, int numeroEsperado)
        {
            var subject = new NumerosRomanosParser();
            var result = subject.Parse(numeroRomano);
            result.Should().Be(numeroEsperado);
        }
    }
}
