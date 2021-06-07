using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NumerosRomanosLibrary
{
    public class NumerosRomanosParser : INumerosRomanosParser
    {
        static Regex _regexNumerosRomanos = new Regex("^(M|MM|MMM)?(C|CC|CCC|CD|D|DC|DCC|DCCC|CM)?(X|XX|XXX|XL|L|LX|LXX|LXXX|XC)?(I|II|III|IV|V|VI|VII|VIII|IX)?$");

        public bool IsValid(string numeroRomano)
        {
            if (string.IsNullOrEmpty(numeroRomano))
                return false;
            if (!_regexNumerosRomanos.IsMatch(numeroRomano))
                return false;
            return true;
        }

        public int Parse(string numeroRomano)
        {
            if (!IsValid(numeroRomano))
                throw new ArgumentException("Numero romano inválido!");

            var parsed = _regexNumerosRomanos.Match(numeroRomano);

            var g1 = parsed.Groups[1].Value;
            var g2 = parsed.Groups[2].Value;
            var g3 = parsed.Groups[3].Value;
            var g4 = parsed.Groups[4].Value;

            int result = calcNumber(g1, 'M', '.', '.', 1000)
                         + calcNumber(g2, 'C', 'D', 'M', 100)
                         + calcNumber(g3, 'X', 'L', 'C', 10)
                         + calcNumber(g4, 'I', 'V', 'X', 1);

            return result;
        }

        private int calcNumber(string chunk, char unit, char multiple5, char multiple10, int baseNumber)
        {
            if (chunk == unit.ToString() + multiple5.ToString())
                return 4 * baseNumber;
            if (chunk == unit.ToString() + multiple10.ToString())
                return 9 * baseNumber;
            return (chunk.Count(x => x == unit) + chunk.Count(x => x == multiple5) * 5) * baseNumber;
        }
    }
}
