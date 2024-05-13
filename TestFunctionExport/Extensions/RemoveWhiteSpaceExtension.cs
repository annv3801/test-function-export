using System.Text;

namespace ExportExcel.Extensions;

public static class RemoveWhiteSpaceExtension
{
    private static readonly string[] _charactersValid =
    {
        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", 
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", 
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
    };

    public static string FilterValidCharacters(this string input)
    {
        var stringBuilder = new StringBuilder();

        foreach (var c in input)
            if (_charactersValid.Contains(c.ToString()))
                stringBuilder.Append(c);

        return stringBuilder.ToString();
    }
}