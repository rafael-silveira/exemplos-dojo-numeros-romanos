using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NumerosRomanosLibrary;
using Xunit;

namespace NumerosRomanosUnitTestsLibrary
{
    public class NumerosRomanosParserUnitTests
    {
        [Fact]
        public void Parse_StringValidaI_Numero1Obtido()
        {
            var subject = new NumerosRomanosParser();

            var result = subject.Parse("I");

            result.Should().Be(1);
        }

        [Fact]
        public void Parse_StringValidaII_Numero2Obtido()
        {
            var subject = new NumerosRomanosParser();

            var result = subject.Parse("II");

            result.Should().Be(2);
        }

        [Fact]
        public void Parse_StringValidaV_Numero5Obtido()
        {
            var subject = new NumerosRomanosParser();

            var result = subject.Parse("V");

            result.Should().Be(5);
        }

    }
}
