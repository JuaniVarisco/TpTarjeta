using Tarjeta1;

namespace Tarjeta1
{
    public class Boleto_Larga_Distancia : Boleto
    {
        public Boleto_Larga_Distancia(int idBoleto, string tipoTarjeta, string lineaColectivo, float totalAbonado, float saldoRestante, DateTime tiempo, bool cancelaSaldoNegativo = false)
            : base(idBoleto, tipoTarjeta, lineaColectivo, totalAbonado, saldoRestante, tiempo, cancelaSaldoNegativo)
        {
            precio = 2500;
        }
    }
}
