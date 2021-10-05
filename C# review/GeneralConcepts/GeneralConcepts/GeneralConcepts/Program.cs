using GeneralConcepts.common;
using GeneralConcepts.Folder2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralConcepts
{
    class Program
    {
        static void Main(string[] args)
        {

            /*int myNum = 15;
            int[] myArray = new int[3] {1, 2 ,3 };

            var team = new Team("barcelona FC", "Barcelona");

            team.FundedIn = new DateTime(1889, 5, 12);

            Console.WriteLine($"the team was founded in {team.FundedIn} and 2 + 2 is {2 + 2} ");

            Team team2 = team;
            team2 = null;
            team = null; 
            */

            //generics demo
            //Generics.Tester.Test();

            //Delegates and lambdas demo
            //GeneralConcepts.DelegatesAndLambdas.Tester.Test();

            var employees = new List<Employee>();
  

            var result = employees
                    .Select(category => category.Name)
                    .DefaultIfEmpty("")
                    .Aggregate((acc, val) => (string.IsNullOrWhiteSpace(val) || string.IsNullOrEmpty(val)?acc : $"{acc}, {val}"));


            
            //Linq demo
            GeneralConcepts.Linq.Tester.Test(); 

            var poco = new POCO();

        }
    }
}
