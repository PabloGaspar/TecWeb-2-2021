using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralConcepts.common
{
    public class Team
    {
        private string Name;
        private string City;

        public Team(string name, string city)
        {
            this.Name = name;
            this.City = city;
        }

        public DateTime FundedIn { get; set; }

        private int myVar;

    }
}
