namespace InvoiceApp
{
    public class ElectronicServiceInvoice : Invoice
    {
        //Constructor de la clase derivada ElectronicServiceInvoice, al tener la clase invoice un constructor unico que recibe
        //El parametro amount, debe ser declarado usando la keyword base que indica que debe pasar el parametro a su clase base
        public ElectronicServiceInvoice(decimal amount) : base(amount)
        {
        }

        public override void Buy(TaxType type)
        {
            //A manera de ejemplificacion, estamos invocando directamente la implementacion del metodo Buy de la clase base Invoice.
            //Pudieramos facilmente sobreescribir la logica de nuestro metodo en esta implementación
            base.Buy(type);
        }

        //El metodo ImpuestoPais esta siendo sobrescrito para implementar su logica
        //En este caso el metodo en su clase base multiplica por 30%, pero aca sobreescribimos y calculamos en base al 8%
        public override decimal ImpuestoPais(TaxType type)
        {
            decimal value = 0;

            value = (Amount * new Taxes().ImpuestoPaisElectronico) / 100.00M;

            Add("Percepcion 35%", value);

            return value;
        }

        public override decimal Percepcion(TaxType type)
        {
            return base.Percepcion(type);
        }
    }
}
