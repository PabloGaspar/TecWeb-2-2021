using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Models
{
    public class TeamWithPlayerModel : TeamModel
    {
        public IEnumerable<PlayerModel> Players { get; set; }

    }
}
