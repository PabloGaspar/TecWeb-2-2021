using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedConcepts
{
    public static class TaskDemo
    {
        public static async Task Test()
        {
            //TestTaskBasics();
            TestChef();
            //TestChefAsync();
            while (true)
            {
                string result = Console.ReadLine();
                Console.WriteLine("You typed: " + result);
            }
        }

        public static void TestTaskBasics()
        {
            Action<object> action = (object param) =>
            {
                //only recives object needs casting 
                Console.WriteLine($" Task= {Task.CurrentId} Thread={Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($" Param= {param}");
                Thread.Sleep(5000);
                Console.WriteLine($"Task: {Task.CurrentId} finished");
            };

            // Create a task but do not start it.
            Task t1 = new Task(action, "parameter 1");

            t1.Start();

            Console.WriteLine("After task 1 was runned");

            Console.ReadLine();

            // Construct a started task
            Task t2 = Task.Factory.StartNew(action, "parameter 2");
            // Block the main thread to demonstrate that t2 is executing
            t2.Wait();

            Console.WriteLine("After task 2 was runned");

            var mytasktowait = Task.Run(() => {

                Console.WriteLine("run from lambda");
            });

            mytasktowait.Wait();

            Task<int> taskWithResult = Task<int>.Run(() => {
                // Just loop.
                int max = 1000000;
                int ctr = 0;
                for (ctr = 0; ctr <= max; ctr++)
                {

                }
                return ctr;
            });

            Console.WriteLine("Finished Task With Result 1 {0:N0} iterations.", taskWithResult.Result);

            var taskWithResult2 = Task<int>.Run(() => {
                // Just loop.
                int max = 1000000;
                int ctr = 0;
                for (ctr = 0; ctr <= max; ctr++)
                {

                }
                return ctr;
            }).GetAwaiter();
            Console.WriteLine("Finished {0:N0} iterations.", taskWithResult.Result);
        }

        public async static Task TestChef()
        {
            Console.Clear();

            var chef = new Chef();

            var chickenAsyncTask = chef.PutChickenInTheOvenAsync();
         
            Thread.Sleep(1000);

            var salad = chef.PrepareSalad();
            Console.WriteLine($"{salad} : is ready");

            var chicken = await chickenAsyncTask;
            Console.WriteLine($"{chicken} : is ready");

            Console.WriteLine($"your dish with {chicken} and {salad} is ready");
        }

        public async static Task TestChefAsync()
        {
            Console.Clear();

            var chef = new ChefAsync();

            var chickenTask = chef.PutChickenInTheOvenAsync();

            Thread.Sleep(1000);

            var salad = chef.PrepareSalad();
            Console.WriteLine($"{salad} : is ready");

            var chicken = await chickenTask;
            Console.WriteLine($"{chicken} : is ready");
        }
    }

    public class Chef
    {
        public async Task<string> PutChickenInTheOvenAsync()
        {
            var chikenTask = Task.Run(()=> {
                Console.WriteLine("putting the chicken in the oven");
                Thread.Sleep(30000);
                Console.WriteLine("getting the chicken from the oven");
                //return  "fried chicken"
            });


            /*
             * var chicken = await chikenTask;
             * return chicken;
             */
            await chikenTask;

            //mucho codigo  ........
            return "fried chicken";
        }

        public string PrepareSalad()
        {
            Console.WriteLine("starting slicing salad");
            Thread.Sleep(5000);
            Console.WriteLine("finished salad");
            return "a healty salad";
        }
    }

    public class ChefAsync
    {
        public async Task<string> PutChickenInTheOvenAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("putting the chicken in the oven");
                Thread.Sleep(30000);
                Console.WriteLine("getting the chicken from the oven");
            });

            
            return "fried chicken";
        }

        public string PrepareSalad()
        {
            Console.WriteLine("starting slicing salad");
            Thread.Sleep(5000);
            Console.WriteLine("finished salad");
            return "a healty salad";
        }
    }
}
