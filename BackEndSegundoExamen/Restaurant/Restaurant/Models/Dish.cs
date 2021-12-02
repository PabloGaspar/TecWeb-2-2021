using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Dish
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Restaurant { get; set; }
    }
}
