namespace Project.Skintific.Scripts.Currency
{
    public class CurrencyHolder
    {
        public string type;
        public long amountOwned;

        public CurrencyHolder(string type, long amountOwned)
        {
            this.type = type;
            this.amountOwned = amountOwned;
        }
    }
}