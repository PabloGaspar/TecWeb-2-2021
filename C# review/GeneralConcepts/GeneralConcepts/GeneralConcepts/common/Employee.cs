using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralConcepts
{
    public abstract class Employee 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string GetInfo()
        {
            //var result = string.Format("My name is {0} and I am {1} and {0}", this.Name, this.Age);
            return $"My name is {Name} and I am {Age}, and 2+ 2 is {2+2}";
        }

        public virtual string Skill()
        {
            return string.Empty;
        }
    }
        
            
}
