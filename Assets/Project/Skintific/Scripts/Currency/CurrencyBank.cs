using System.Collections.Generic;

namespace Project.Skintific.Scripts.Currency
{
    public class CurrencyBank
    {
        private readonly Dictionary<string, CurrencyHolder> currencyHolders = new Dictionary<string, CurrencyHolder>();

        public void Add(string currencyType, long amountToAdd)
        {
            var currencyHolder = GetCurrencyHolderByType(currencyType);
            currencyHolder.amountOwned += amountToAdd;
        }

        private CurrencyHolder GetCurrencyHolderByType(string type)
        {
            if (currencyHolders.ContainsKey(type)) return currencyHolders[type];
            
            var currencyHolder = new CurrencyHolder(type, 0);
            currencyHolders.Add(type, currencyHolder);
            return currencyHolder;

        }
    }
}