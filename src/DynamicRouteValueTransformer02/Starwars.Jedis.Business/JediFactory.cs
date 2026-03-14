using Starwars.Jedis.Entities;

namespace Starwars.Jedis.Business;

public class JediFactory
{
    public Jedi? Jedi { get; private set; }

    public JediFactory()
    {
    }

    public JediFactory(Jedi jedi)
    {
        Jedi = jedi;
    }

    public JediFactory SetJedi(Jedi jedi)
    {
        Jedi = jedi;
        return this;
    }
}
