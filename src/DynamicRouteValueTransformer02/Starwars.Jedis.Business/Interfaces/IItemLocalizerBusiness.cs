using System.Collections.Generic;
using Starwars.Jedis.Entities;

namespace Starwars.Jedis.Business.Interfaces;

public interface IItemLocalizerBusiness
{
    List<ItemLocalizable> List();

    ItemLocalizable? GetByEndpoint(string language, string itemEndpoint);

    ItemLocalizable? GetByKey(string language, string itemKey);
}
