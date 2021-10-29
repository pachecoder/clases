using InvoiceApp;
using System;
using System.Collections.Generic;

namespace BuyCash.App.Repository
{
    public class Response
    {
        public Customer Customer { get; set; }

        public List<Details> Details { get; set; }

        //Propiedad de solo lectura, cualquier intento de escribirle generara un error de compilación
        public DateTime BuyDate { get; } = DateTime.Now;
    }
}
