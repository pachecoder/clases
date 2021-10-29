using System.ComponentModel.DataAnnotations;

namespace BuyCash.App.Repository
{
    public class Transaction
    {
        public decimal Amount { get; set; }

        //Parametro requerido a nivel de modelo del controllador, si el mismo no esta presenta no permite la request
        //Mas adelante veremos como usar FluentValidator y no hacer validaciones a nivel de Atributo [Required]
        [Required]
        public Customer Customer { get; set; }
    }
}
