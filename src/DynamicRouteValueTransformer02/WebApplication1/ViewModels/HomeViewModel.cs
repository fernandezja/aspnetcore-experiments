using Starwars.Jedis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class HomeViewModel
    {
        public List<Jedi> Jedis { get; set; }
        public List<ItemLocalizable> Groups { get; set; }
    }
}
