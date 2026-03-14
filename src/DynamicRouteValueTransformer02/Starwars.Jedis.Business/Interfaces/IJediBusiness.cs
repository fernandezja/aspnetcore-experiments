using System.Collections.Generic;
using Starwars.Jedis.Entities;

namespace Starwars.Jedis.Business.Interfaces;

public interface IJediBusiness
{
    List<Jedi> List();

    Jedi? GetByEndpoint(string jediEndpoint);

    Jedi? GetById(int id);
}
