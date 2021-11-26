using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Models
{
    public class TeamFormModel : TeamModel
    {
        public IFormFile Image { get; set; }
    }
}
