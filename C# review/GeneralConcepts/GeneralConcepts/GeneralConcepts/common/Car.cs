using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralConcepts
{
    public enum CarType
    {
        Ferrary,
        Escarabajo,
        Mustang = 13
    }

    public enum ColorTypes
    {
        White,
        Red,
        Black
    }
    
    public class Car
    {
       /* private string _color;

        public string GetColor() 
        {
            if (string.IsNullOrEmpty(this._color))
            {
                return "emtpy";
            }
            else
            {
                return _color;
            }
            
        }

        public void SetColor(string newColor)
        {
            if (newColor.Length> 1000)
            {
                this._color = "nocolor";
            }
            this._color = newColor;
        }

        private int myVar;

        public int MyProperty
        {
            get 
            {
                if (myVar > 6)
                {
                    myVar = myVar + 6;
                }
                return myVar; 
            }
            set 
            { 
                myVar = value; 
            }
        }*/

        public string OwnerName { get; set; }
        public int OwnerAge { get; set; }
        public CarType type { get; set; }
    }
}
