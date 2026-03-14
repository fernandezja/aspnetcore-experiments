namespace Starwars.Jedis.Entities;

public class Group
{
    public ItemLocalizable ItemLocalizable { get; set; } = null!;

    public Jedi Jedi { get; set; } = null!;
}
