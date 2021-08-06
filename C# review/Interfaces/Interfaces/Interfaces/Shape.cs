using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public abstract class Shape
    {
        public abstract int GetArea();
        public string sayHi() {
            return "hi";
        }

        public void InitializeRendering()
        {

        }
    }

    public class Square : Shape
    {
        private int side;
        public override int GetArea()
        {
            return side* side;
        }
    }
}
