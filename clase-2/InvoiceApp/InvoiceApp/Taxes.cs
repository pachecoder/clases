namespace InvoiceApp
{

    //Una clase sealed solo puede ser instanciada pero no puede ser implementada.
    //Ejemplo clase Hija:Padre no se puede hacer ya que el modificador de acceso sealed lo prohibe.
    //Si podemos crear es una nueva instancia ejemplo var miclase = new ClaseSealed(); Es correcto.
    public sealed class Taxes
    {
        public decimal Percepcion35 { get; } = 35.00M;

        public decimal ImpuestoPais { get; } = 30.00M;

        public decimal ImpuestoPaisElectronico { get; } = 8.00M;
    }
}
