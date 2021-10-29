using BuyCash.App.Repository;
using InvoiceApp;
using Microsoft.AspNetCore.Mvc;

namespace BuyCash.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        //Accion del controller transaction, esta Action ha recibido el nombre de Buy
        [HttpPost("Buy")]
        //Definimos los StatusCode y el formato a responder segun cada uno de ellos
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(typeof(string), 400)]
        //Esta Actión recibe un objeto de tipo Transaction
        public IActionResult Buy(Transaction transaction)
        {
            //Validamos que la compra sea superior a 0
            if(transaction.Amount <= 0)
            {
                //Retornamos el mensaje de error y un StatusCode 400
                return BadRequest("Usted debe colocar un monto superior a 0.");
            }

            //Realizamos la compra
            Invoice invoice = new Invoice(transaction.Amount);

            invoice.Buy(TaxType.Person);
            invoice.ImpuestoPais(TaxType.Person);
            invoice.Percepcion(TaxType.Person);
            //"Enviamos" un email con el detalle de la compra
            invoice.SendEmail();

            //Inicializamos los datos que contendra nuestro response
            var response = new Response {
                Customer = transaction.Customer,
                Details = invoice.GetInvoiceDetails()
            };

            //Se devuelve el objeto e indicamos que todo esta OK = 200.
            return Ok(response);
        }
    }
}
