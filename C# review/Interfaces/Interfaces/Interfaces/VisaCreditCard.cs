using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class VisaCreditCard : ICreditCard
    {
        private string owner;
        private decimal maxAmount;
        private const string brand = "Visa Card";


        public string Owner 
        { 
             get { return owner; }
             set { owner = value; } 
        }

        public decimal MaxAmount
        {
            get => maxAmount;
            set => maxAmount = value; 
        }



        public decimal CalculateInterest(decimal amount)
        {
            if (amount > 10000)
            {
                return amount * 0.05m;
            }
            else
            {
                return amount * 0.02m;
            }
        }

        public string GetBrand()
        {
            return $"Im am {brand}";
        }

        public CardHolderInfo GetHolderInformation()
        {
            return new CardHolderInfo() { Name = $"The owner is {owner}" };
        }
    }
}
