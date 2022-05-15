using System.Collections.Generic;

namespace Project.Skintific.Scripts.Currency
{
    public class CurrencyBank
    {
        private readonly Dictionary<string, CurrencyHolder> _currencyHolders = new Dictionary<string, CurrencyHolder>();

        public void Add(string currencyType, long amountToAdd)
        {
            var currencyHolder = GetCurrencyHolderByType(currencyType);
            currencyHolder.amountOwned += amountToAdd;
        }

        private CurrencyHolder GetCurrencyHolderByType(string type)
        {
            if (_currencyHolders.ContainsKey(type)) return _currencyHolders[type];
            
            var currencyHolder = new CurrencyHolder(type, 0);
            _currencyHolders.Add(type, currencyHolder);
            return currencyHolder;

        }
    }
}