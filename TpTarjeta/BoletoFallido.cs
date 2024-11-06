using Tarjeta1;

namespace Tarjeta1
{
    public class Boleto_Fallido : Boleto
    {
        public string cartel = "No se pudo realizar el pago";
        public Boleto_Fallido()
            : base(0, "", "", 0, 0, DateTime.Now, false)
        {
            precio = 0;
        }
    }
}
