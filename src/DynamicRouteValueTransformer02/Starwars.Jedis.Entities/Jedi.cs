namespace Starwars.Jedis.Entities;

public class Jedi
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Jedi(int id, string name)
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    /// Return the name to format url.
    /// Example: Obi-Wan Kenobi > obi-wan-kenobi
    /// </summary>
    public string Endpoint =>
        StringHelper.RemoveSpecialCharacters(
            StringHelper.RemoveDiacritics(
                Name.Replace(Constants.WHITESPACE_CHAR, Constants.HYPHEN_CHAR)))
        .ToLowerInvariant();
}
