using System;

namespace InvoiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("##### Invoice Person ##### \n");

            var invoice = new Invoice(1000);

            invoice.Buy(TaxType.Person);

            invoice.ImpuestoPais(TaxType.Person);

            invoice.Percepcion(TaxType.Person);

            invoice.SendEmail();


            Console.WriteLine("##### Invoice No Tax ##### \n");

            var invoiceNoTax = new Invoice(1000);

            invoiceNoTax.Buy(TaxType.NoTax);

            invoiceNoTax.ImpuestoPais(TaxType.NoTax);

            invoiceNoTax.Percepcion(TaxType.NoTax);

            invoiceNoTax.SendEmail();


            Console.WriteLine("##### Invoice Electronic Service ##### \n");

            var electronicInvoice = new ElectronicServiceInvoice(2000);

            electronicInvoice.Buy(TaxType.Electronic);

            electronicInvoice.ImpuestoPais(TaxType.Electronic);

            electronicInvoice.Percepcion(TaxType.Electronic);

            electronicInvoice.SendEmail();

            Console.ReadKey();
        }
    }
}
