using System.Collections.Generic;
using System.Linq;
using Starwars.Jedis.Business.Interfaces;
using Starwars.Jedis.Entities;

namespace Starwars.Jedis.Business;

public class ItemLocalizerBusiness : IItemLocalizerBusiness
{
    public List<ItemLocalizable> List()
    {
        return
        [
            new ItemLocalizable("en", "dark-side", "Dark Side"),
            new ItemLocalizable("es", "dark-side", "Lado Oscuro"),
            new ItemLocalizable("pt", "dark-side", "Lado Escuro"),
            new ItemLocalizable("fr", "dark-side", "Côté Obscur"),
            new ItemLocalizable("en", "light-side", "Light Side"),
            new ItemLocalizable("es", "light-side", "Lado Luminoso"),
            new ItemLocalizable("pt", "light-side", "Lado Claro"),
            new ItemLocalizable("fr", "light-side", "Côté Clair"),
            new ItemLocalizable("en", "empire", "Empire"),
            new ItemLocalizable("es", "empire", "Imperio"),
            new ItemLocalizable("pt", "empire", "Império "),
            new ItemLocalizable("fr", "empire", "Empire"),
            new ItemLocalizable("en", "rebels", "Rebels"),
            new ItemLocalizable("es", "rebels", "Rebeldes"),
            new ItemLocalizable("pt", "rebels", "Rebeldes"),
            new ItemLocalizable("fr", "rebels", "Rebelles"),
            new ItemLocalizable("en", "first-order", "First Order"),
            new ItemLocalizable("es", "first-order", "Primera Orden"),
            new ItemLocalizable("pt", "first-order", "primeira Ordem"),
            new ItemLocalizable("fr", "first-order", "Premier Ordre")
        ];
    }

    public ItemLocalizable? GetByEndpoint(string language, string itemEndpoint)
    {
        return List().FirstOrDefault(item =>
            item.Endpoint == itemEndpoint &&
            item.Language == language);
    }

    public ItemLocalizable? GetByKey(string language, string itemKey)
    {
        return List().FirstOrDefault(item =>
            item.Key == itemKey &&
            item.Language == language);
    }
}
