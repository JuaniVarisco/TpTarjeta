using Tarjeta1;

namespace Tarjeta1
{
    public class Boleto_Urbano : Boleto
    {
        public Boleto_Urbano(int idBoleto, string tipoTarjeta, string lineaColectivo, float totalAbonado, float saldoRestante, DateTime tiempo, bool cancelaSaldoNegativo = false)
            : base(idBoleto, tipoTarjeta, lineaColectivo, totalAbonado, saldoRestante, tiempo, cancelaSaldoNegativo)
        {
            precio = 1200;
        }
    }
}
