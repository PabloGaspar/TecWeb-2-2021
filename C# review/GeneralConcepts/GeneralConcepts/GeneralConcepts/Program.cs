using GeneralConcepts.Folder2;
using System;

namespace GeneralConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            //generics demo
            //Generics.Tester.Test();

            //Delegates and lambdas demo
            //GeneralConcepts.DelegatesAndLambdas.Tester.Test();

            //Linq demo
            GeneralConcepts.Linq.Tester.Test();

            var poco = new POCO();

        }
    }
}
