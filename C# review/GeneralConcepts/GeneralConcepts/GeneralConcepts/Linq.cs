using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralConcepts.Linq
{
    public static class Tester
    {
        public static void Test()
        {
            //IEnumerable

            var testList = new List<Employee>();
            testList.Add(new Developer
            {
                Age = 11,
                Name = "Alison",
            });

            testList.Add(new QA()
            {
                Age = 13,
                Name = "Careu"
            });

            foreach (var item in testList)
            {
                Console.WriteLine(item.Skill());
            }

            var testDicionary = new Dictionary<int, Employee>();

            testDicionary.Add(13, new Developer() { Name = "Mara", Id = 13 });

            testDicionary[22] = new Developer() { Name = "Pepa", Id = 22 };
            testDicionary[55] = new Developer { Name = "yo", Id = 55 };

            var boolExist = testDicionary.ContainsKey(22);

            var boolNotExist = testDicionary.ContainsKey(3);

            var yo = testDicionary[55];



            //Linq
            var devsToWork = PopulateDevelopers();

            //Func<TSource, bool>
            var newList = devsToWork.Where((Developer developer) => {return developer.Age > 50; }); 
            //Filtering 
            var lessThan30 = devsToWork.Where((e) =>  e.Age < 30); //&& e.something == 2
            var anas = devsToWork.Where(d => d.Name == "Ana");

            //First
            var firstNameD = devsToWork.FirstOrDefault(e => e.Name.StartsWith("D"))?? new Developer();
            var firstNameW = devsToWork.FirstOrDefault(e => e.Name.StartsWith("W")) ?? new Developer();
            var firstNameD2 = devsToWork.SingleOrDefault(e => e.Id == 2);

            //Ordering
            var orderedlistByIdAsc = devsToWork.OrderBy((e) => { return e.Age; }).ThenByDescending(e => e.Name);

            var orderedlistByIdAsc_2 = from element in devsToWork
                                       where element.Age > 22
                                       orderby element.Name descending
                                       select new Car() { OwnerName = element.Name };

            //Projection Selecting 
            var carProjection = devsToWork
                .Where(e => e.Name.StartsWith("D"))
                .Select(e => {
                    return new Car()
                    {
                        OwnerName = e.Name,
                        OwnerAge = e.Age,
                        type = e.Age < 30 ? CarType.Ferrary : CarType.Escarabajo
                    };
                });

            var age = 12;
     

            var listNames = new List<string>() { "Maria", "pepe", "pedro", "sebastian" };

            var size = listNames.Count;
            var nameLenght = listNames.Select(e => {return  e.Length;});


            var carProjectionSame = devsToWork
                .Where(e => e.Name.StartsWith("D"))
                .Select(e => 
                {
                    //you can add more code here
                    int number = 12;

                    return new Car()
                    {
                        OwnerName = e.Name,
                        OwnerAge = e.Age,
                        type = e.Age < 30 ? CarType.Ferrary : CarType.Escarabajo
                    };
                });

            var lessThan30_2 = from element in devsToWork
                               where element.Age < 30
                               select element;

            var carProjectionQuery = from element in devsToWork
                                     where element.Name.StartsWith("D")
                                     select new Car()
                                     {
                                         OwnerName = element.Name,
                                         OwnerAge = element.Age,
                                         type = element.Age < 30 ? CarType.Ferrary : CarType.Escarabajo
                                     };


            var anonymous = new  { Color = "ble", Shape = "Square" };
            var color = anonymous.Color;
            
            // anonymous class 
            //Projection Selecting 
            var carProjectionAnonymous = devsToWork
                .Where(e => e.Name.StartsWith("D"))
                .Select(e =>
                    new 
                    {
                        HolderName = e.Name,
                        CardType = "Master Card", 
                        Amount = 1660
                    }
                );
            // read only
            var amount =  carProjectionAnonymous.FirstOrDefault().Amount;

            // Grouping
            var groupedByName = devsToWork.GroupBy(e => e.Name);

            foreach (var nameGroup in groupedByName)
            { 
                Console.WriteLine($"The Key: {nameGroup.Key}");

                foreach (var developer in nameGroup)
                {
                    Console.WriteLine(developer.GetInfo());
                }

            }

            var groupedByAge = from element in devsToWork
                               group element by element.Age;


            // Joining 
            var accountToWork = populateAccounts();

            var joinedDevelopersAccounts = from dev in devsToWork
                                           join acc in accountToWork on dev.Id equals acc.EmployeeId
                                           select new
                                           {
                                               Name = dev.Name,
                                               AccountName = acc.AccountName,
                                               AccountAmount  = acc.Amount,
                                           };

            foreach (var joined in joinedDevelopersAccounts)
            {
                Console.WriteLine($"{joined.Name} - {joined.AccountName} - {joined.AccountAmount} ");
            }

        }

        public static List<Developer> PopulateDevelopers()
        {
            var result = new List<Developer>();

            result.Add(new Developer() { Id = 22, Name = "Ana", Age = 22 });
            result.Add(new Developer() { Id = 98, Name = "Donald", Age = 77 });
            result.Add(new Developer() { Id = 2, Name = "David", Age = 18 });
            result.Add(new Developer() { Id = 26, Name = "Gerald", Age = 60 });
            result.Add(new Developer() { Id = 4, Name = "Xavier", Age = 32 });
            result.Add(new Developer() { Id = 23, Name = "David", Age = 40 });
            result.Add(new Developer() { Id = 45, Name = "Carl", Age = 18 });
            result.Add(new Developer() { Id = 31, Name = "Harnold", Age = 41 });
            result.Add(new Developer() { Id = 70, Name = "Ana", Age = 34 });
            result.Add(new Developer() { Id = 28, Name = "Bob", Age = 22 });
            return result;
        }

        public static List<Account> populateAccounts()
        {
            var result = new List<Account>();

            result.Add(new Account() { AccountName = "Santader Bo", Amount = 7654, EmployeeId = 22 });
            result.Add(new Account() { AccountName = "Santader Bo 2", Amount = 765, EmployeeId = 45 });
            result.Add(new Account() { AccountName = "Visa Bo", Amount = 453, EmployeeId = 45 });
            result.Add(new Account() { AccountName = "Visa Bo2", Amount = 9985, EmployeeId = 28 });
            result.Add(new Account() { AccountName = "Barclay ", Amount = 574, EmployeeId = 70 });
            result.Add(new Account() { AccountName = "Santader" , Amount = 679, EmployeeId = 26 });
            result.Add(new Account() { AccountName = "Master ", Amount = 4457, EmployeeId = 2 });



            return result;
        }



    }
}
