using System.Collections.Generic;
using System.Linq;
using Starwars.Jedis.Business.Interfaces;
using Starwars.Jedis.Entities;

namespace Starwars.Jedis.Business;

public class JediBusiness : IJediBusiness
{
    public List<Jedi> List()
    {
        return
        [
            new Jedi(1, "Yoda"),
            new Jedi(2, "Mace Windu"),
            new Jedi(3, "Count Dooku"),
            new Jedi(4, "Qui-Gon Jinn"),
            new Jedi(5, "Obi-Wan Kenobi"),
            new Jedi(6, "Anakin Skywalker"),
            new Jedi(7, "Ahsoka Tano"),
            new Jedi(8, "Cal Kestis"),
            new Jedi(9, "Cere Junda"),
            new Jedi(10, "Kanan Jarrus"),
            new Jedi(11, "Ezra Bridger"),
            new Jedi(12, "Luke Skywalker"),
            new Jedi(13, "Ben Solo"),
            new Jedi(14, "Rey")
        ];
    }

    public Jedi? GetByEndpoint(string jediEndpoint)
    {
        return List().FirstOrDefault(jedi => jedi.Endpoint == jediEndpoint);
    }

    public Jedi? GetById(int id)
    {
        return List().FirstOrDefault(jedi => jedi.Id == id);
    }
}
