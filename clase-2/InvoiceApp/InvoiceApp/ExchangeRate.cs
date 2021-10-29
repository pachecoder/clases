namespace InvoiceApp
{
    //Una clase estatica podemos usarla sin necesidad de crear una instancia, pero sus metodos deben ser estaticos.
    public static class ExchangeRate
    {
        public static decimal GetUsDollars()
        {
            return 200.00M;
        }
    }
}
