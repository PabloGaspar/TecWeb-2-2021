using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    class BNBCreditCard : ICreditCard
    {
        public string Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal MaxAmount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public decimal CalculateInterest(decimal amount)
        {
            throw new NotImplementedException();
        }

        public string GetBrand()
        {
            throw new NotImplementedException();
        }

        public CardHolderInfo GetHolderInformation()
        {
            throw new NotImplementedException();
        }
    }
}
