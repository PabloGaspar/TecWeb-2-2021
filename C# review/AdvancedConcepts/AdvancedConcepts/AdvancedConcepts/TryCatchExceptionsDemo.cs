using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedConcepts
{
    public class TryCatchExceptionsDemo
    {
        public static void Test()
        {
            
            try
            {
                SomeMethod();
                //mas codigo
            }
            catch(MyException ex)
            {
                Console.WriteLine("MyException");
            }
            catch (Exception ex)
            {

                throw;
            }
            // SQLExeption -> DatabaseExeption -> Exception
            // BadAgeException -> Exception
            int x = 0;
            try
            {
                object myObject = new object();
                myObject.ToString();
                //throw new Exception("soemthing happend");
                int y = 100 / x;
            }
            catch (ArithmeticException e)
            {
                var message = e.Message;
                Console.WriteLine($"ArithmeticException Handler: {e}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Generic Exception Handler: {e}");
            }


            int someResult = 400;

            try
            {
                if (someResult == 400)
                {
                    throw new MyException() { erroType = ErroType.Critical, additionalIndormation = "is the end of the world" };
                }
                else if (someResult == 300)
                {
                    throw new MyException() { erroType = ErroType.Warning, additionalIndormation = "don't worry be happy" };
                }
            }
            catch (MyException ex)
            {

                Console.WriteLine(ex.additionalIndormation);
                throw ex;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void SomeMethod()
        {
            int i = 10;
            /***********do stuff here**/
            throw new MyException(){ additionalIndormation = "erro", erroType = ErroType.Critical};
        }
    }

    public enum ErroType
    {
        Critical,
        Normal,
        Warning
    }

    public class MyException : Exception
    {
        public ErroType erroType { get; set; }
        public string additionalIndormation { get; set; }
    }
}
