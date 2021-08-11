using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralConcepts.common
{
    static class Extensions
    {
        public static void SayHi(this Car car, string sound)
        {
            Console.WriteLine($"hi im ammmmmmmm carr  {car.OwnerName} - {sound}");
        }
    }
}
