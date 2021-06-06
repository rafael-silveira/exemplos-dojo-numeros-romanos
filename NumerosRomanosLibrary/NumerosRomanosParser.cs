using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NumerosRomanosLibrary
{
    public class NumerosRomanosParser
    {
        public int Parse(string numeroRomano)
        {
            int result = 0;

            var regexParser = new Regex("^(M|MM|MMM)?(C|CC|CCC|CD|D|DC|DCC|DCCC|CM)?(X|XX|XXX|XL|L|LX|LXX|LXXX|XC)?(I|II|III|IV|V|VI|VII|VIII|IX)?$");
            var parsed = regexParser.Match(numeroRomano);

            var g1 = parsed.Groups[1].Value;
            var g2 = parsed.Groups[2].Value;
            var g3 = parsed.Groups[3].Value;
            var g4 = parsed.Groups[4].Value;

            switch (g4)
            {
                case "I":
                    result += 1;
                    break;
                case "II":
                    result += 2;
                    break;
                case "III":
                    result += 3;
                    break;
                case "IV":
                    result += 4;
                    break;
                case "V":
                    result += 5;
                    break;
                case "VI":
                    result += 6;
                    break;
                case "VII":
                    result += 7;
                    break;
                case "VIII":
                    result += 8;
                    break;
                case "IX":
                    result += 9;
                    break;
            }

            return result;
        }
    }
}
