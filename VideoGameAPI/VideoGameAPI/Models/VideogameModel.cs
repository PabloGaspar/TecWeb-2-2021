using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameAPI.Models
{
    public class VideogameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ESRB { get; set; }
        public string Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal? Price { get; set; }
        public int CompanyId { get; set; }
    }
}
