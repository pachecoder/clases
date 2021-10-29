using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApp
{
    public class Invoice : Calculation, ICurrency
    {
        //fields privado de detalles el cual nos permitira retornar el detalle de los impuestos
        private List<Details> details;

        public decimal Amount { get; set; }


        //Constructor de la clase Invoice el cual recibe el monto a adquirir
        public Invoice(decimal amount)
        {
            Amount = amount;

            details = new List<Details>();
        }

        //Metodo que debe ser implementado que parte de un metodo abstracto en la clase abstract Calculation
        public override void Buy(TaxType type)
        {
            Add("Cantidad de Pesos", Amount);
        }

        //El modificador de acceso virtual nos permitira en clases derivadas sobreescribir la logica del miembro
        //por una nueva logica que se adapte a la necesidad de la clase derivada.
        //En cuanto al modificador de acceso protected, solo podremos usarlo en las clases derivadas, cualquier intento de usarlo
        //en la clase base nos generara un error de compilacion
        public virtual decimal Percepcion(TaxType type)
        {
            decimal value = 0;

            value = (Amount * new Taxes().Percepcion35) / 100.00M;

            if (type is TaxType.NoTax)
            {
                value = 0;
            }

            Add("Percepcion 35%", value);

            return value;
        }

        //metodo con modificador de acceso public, esto permite acceder en subsequentes clases
        //a este metodo y su logica.
        public void Add(string type, decimal value)
        {
            details.Add(new Details { Description = type, Amount = value });
        }

        public virtual decimal ImpuestoPais(TaxType type)
        {
            var taxes = new Taxes();

            decimal value = 0;

            if (type is TaxType.Person)
            {
                value = (Amount * taxes.ImpuestoPais) / 100.00M;
            }
            else if (type is TaxType.NoTax)
            {
                value = 0;
            }

            Add("Impuesto Pais", value);

            return value;
        }

        public string GetDetails()
        {
            var report = new StringBuilder();

            decimal balance = 0;

            report.AppendLine("Description\t\t\tAmount");
            foreach (var item in details)
            {
                balance += item.Amount;
                report.AppendLine($"{ item.Description }|\t\t\t{ item.Amount }");
            }

            return report.ToString();
        }

        public override void SendEmail()
        {
            string resumenCompra = @$"El resumen de su compra fue: { Environment.NewLine } { GetDetails() }, Usted compro la cantidad de: {GetMonedaExtranjera()}$  Gracias por su compra. { Environment.NewLine }";

            Console.WriteLine(resumenCompra);
        }

        public List<Details> GetInvoiceDetails()
        {
            return details;
        }

        public decimal GetMonedaExtranjera()
        {
            return Amount / ExchangeRate.GetUsDollars();
        }
    }
}
