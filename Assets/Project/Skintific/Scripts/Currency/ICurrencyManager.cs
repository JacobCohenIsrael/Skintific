namespace Project.Skintific.Scripts.Currency
{
    public interface ICurrencyManager
    {
        public void Transact(CurrencyTransaction[] currenciesTransaction, CurrencyBank currencyBank);
    }
}