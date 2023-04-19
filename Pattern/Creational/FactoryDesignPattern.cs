using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Creational
{
    internal class FactoryDesignPattern
    {
        /// <summary>
        /// Tạo thẻ dựa vào cardType
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns></returns>
        public static ICreditCard GetCreditCard(string cardType)
        {
            ICreditCard cardDetails = new Default();
            if (cardType == "MoneyBack")
            {
                cardDetails = new MoneyBack();
            }
            else if (cardType == "Titanium")
            {
                cardDetails = new Titanium();
            }
            else if (cardType == "Platinum")
            {
                cardDetails = new Platinum();
            }
            return cardDetails;
        }
        public interface ICreditCard
        {
            string GetCardType();
            int GetCreditLimit();
            int GetAnnualCharge();
        }

        public class MoneyBack : ICreditCard
        {
            public string GetCardType()
            {
                return "MoneyBack";
            }
            public int GetCreditLimit()
            {
                return 15000;
            }
            public int GetAnnualCharge()
            {
                return 500;
            }
        }
        public class Default : ICreditCard
        {
            public string GetCardType()
            {
                return "Default";
            }
            public int GetCreditLimit()
            {
                return 15000;
            }
            public int GetAnnualCharge()
            {
                return 100;
            }
        }

        public class Titanium : ICreditCard
        {
            public string GetCardType()
            {
                return "Titanium Edge";
            }
            public int GetCreditLimit()
            {
                return 25000;
            }
            public int GetAnnualCharge()
            {
                return 1500;
            }
        }

        public class Platinum : ICreditCard
        {
            public string GetCardType()
            {
                return "Platinum Plus";
            }
            public int GetCreditLimit()
            {
                return 35000;
            }
            public int GetAnnualCharge()
            {
                return 2000;
            }
        }
    }

}
