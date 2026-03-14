using System.Text;

namespace Starwars.Jedis.Entities;

public class Jedi(int id, string name)
{
    private const char WhitespaceChar = ' ';
    private const char HyphenChar = '-';

    public int Id { get; set; } = id;
    public string Name { get; set; } = name;

    /// <summary>
    /// Returns the name formatted as a URL segment.
    /// Example: Obi-Wan Kenobi → obi-wan-kenobi
    /// </summary>
    public string Endpoint =>
        RemoveSpecialCharacters(Name.Replace(WhitespaceChar, HyphenChar)).ToLower();

    private static string RemoveSpecialCharacters(string str)
    {
        var sb = new StringBuilder();
        foreach (char c in str)
        {
            if ((c >= '0' && c <= '9')
                || (c >= 'A' && c <= 'Z')
                || (c >= 'a' && c <= 'z')
                || c == '-')
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}
