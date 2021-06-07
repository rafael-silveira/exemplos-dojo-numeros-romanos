namespace NumerosRomanosLibrary
{
    public interface INumerosRomanosParser
    {
        bool IsValid(string numeroRomano);
        int Parse(string numeroRomano);

    }
}
