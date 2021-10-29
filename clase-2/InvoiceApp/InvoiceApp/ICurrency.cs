namespace InvoiceApp
{
    //Una interfaz nos permite definir el contrato de una implementacion
    //no definen logica siendo simplemente el contrato.
    //Observación: La diferencia entre una interfaz y una clase abstracta
    //Es que la interfaz solo define el contrato y la clase abstracta, define los miembros
    //Los cuales pueden tener logica que será usado en las clases derivadas.

    public interface ICurrency
    {
        decimal GetMonedaExtranjera();
    }
}