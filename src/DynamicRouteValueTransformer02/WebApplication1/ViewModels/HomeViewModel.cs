using System.Collections.Generic;
using Starwars.Jedis.Entities;

namespace WebApplication1.ViewModels;

public class HomeViewModel
{
    public List<Jedi> Jedis { get; init; } = [];

    public List<ItemLocalizable> Groups { get; init; } = [];
}
