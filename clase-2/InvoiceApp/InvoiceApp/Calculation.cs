namespace InvoiceApp
{
    //Clase que puede ser implementada mas no instanciada
    public abstract class Calculation
    {
        //Metodos abstractos, el miembro es definido pero no tiene especificacion de negocio.
        //Obligatoriamente debe ser implementado.
        public abstract void Buy(TaxType type);

        public abstract void SendEmail();
    }
}
