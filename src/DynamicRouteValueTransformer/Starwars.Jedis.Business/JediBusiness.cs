using Starwars.Jedis.Business.Interfaces;
using Starwars.Jedis.Entities;

namespace Starwars.Jedis.Business;

public class JediBusiness : IJediBusiness
{
    public List<Jedi> List() =>
    [
        new(1, "Yoda"),
        new(2, "Mace Windu"),
        new(3, "Count Dooku"),
        new(4, "Qui-Gon Jinn"),
        new(5, "Obi-Wan Kenobi"),
        new(6, "Anakin Skywalker"),
        new(7, "Ahsoka Tano"),
        new(8, "Cal Kestis"),
        new(9, "Cere Junda"),
        new(10, "Kanan Jarrus"),
        new(11, "Ezra Bridger"),
        new(12, "Luke Skywalker"),
        new(13, "Ben Solo"),
        new(14, "Rey"),
    ];

    public Jedi? GetByEndpoint(string jediEndpoint) =>
        List().FirstOrDefault(j => j.Endpoint == jediEndpoint);

    public Jedi? GetById(int id) =>
        List().FirstOrDefault(j => j.Id == id);
}

