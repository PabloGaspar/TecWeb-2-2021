using System;
using System.Collections.Generic;
using System.Text;
using GeneralConcepts.Generics;

namespace GeneralConcepts.DelegatesAndLambdas
{
    //public delegate void ActionDel(Employee emp, string name, int age);
    
    public static class Tester
    {
        public static void Test()
        {
            var qa = new QA();
            // action for void functions
            Action<Employee, string, int> action = OtherAsked;
           // populateEmployee(qa, "Peter", 22);
            action(qa, "Peter", 22);

            // func for return methods
            Func<Employee, string, int, string> func = populateAndShowEmployee;
             var info = func(qa, "Tony", 23);

            ////Lambda expresion
            ///
            // (intput - parameter) => {  expresiones;
           //  expresion;
           //   return something;}
            //(input - parameters) =>  expression 

            Func<Employee, string, int,string> lambdaAction = (employee, name, age) => {
                employee.Name = name;
                employee.Age = age;
                return "SSSSSW";
            };

            Func<string, string> show = name => name.ToUpper(); 

            var res = show("andres");

            Func<Employee, string, int, string> lambdaFunc = (employee, name, age) => {
                employee.Name = name;
                employee.Age = age;
                return $"{employee.GetInfo()} and {employee.Skill()}";
            };

            var dev = new Developer();
            lambdaAction(dev, "Stan", 65);

            var devInfo = lambdaFunc(dev, "Stan", 65);
        }

        public static string populateAndShowEmployee(Employee employee, string name, int age)
        {
            employee.Name = name;
            employee.Age = age;
            return $"{employee.GetInfo()} and {employee.Skill()}";
        }


        public static void OtherAsked(Employee employee, string name, int age)
        {
            employee.Name = name;
            employee.Age = age;
        }



        public static void populateEmployee(Employee employee, string name, int age)
        {
            employee.Name = name;
            employee.Age = age;
        }

        /*
        public void PrepareFood(string FoodName, function DoAfterPreare<Food>)
        {
            bla bla blala 
            var preparedfood;

            DoAfterPreare(preparedfood);
        }*/
    }

    
}
