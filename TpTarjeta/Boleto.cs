/*

namespace Tarjeta1
{
    public class Boleto
    {
        public float precio = 940;
        private int idBoleto;

        public float getPrecio()
        {
            return precio;
        }

        public int getIdBoleto()
        {
            return idBoleto;
        }
    }
}

*/

using System;

namespace Tarjeta1
{
    public class Boleto
    {
        public float precio = 1200;
        private int idBoleto;
        private DateTime fecha;
        private string tipoTarjeta;
        private string lineaColectivo;
        private float totalAbonado;
        private float saldoRestante;
        private string descripcionExtra;

        public Boleto(int idBoleto, string tipoTarjeta, string lineaColectivo, float totalAbonado, float saldoRestante, bool cancelaSaldoNegativo = false)
        {
            this.idBoleto = idBoleto;
            this.tipoTarjeta = tipoTarjeta;
            this.lineaColectivo = lineaColectivo;
            this.totalAbonado = totalAbonado;
            this.saldoRestante = saldoRestante;
            this.fecha = DateTime.Now;
            this.descripcionExtra = cancelaSaldoNegativo ? $"Abona saldo {totalAbonado}" : "Pago normal";
        }

        public float getPrecio()
        {
            return precio;
        }

        public int getIdBoleto()
        {
            return idBoleto;
        }

        public DateTime getFecha()
        {
            return fecha;
        }

        public string getTipoTarjeta()
        {
            return tipoTarjeta;
        }

        public string getLineaColectivo()
        {
            return lineaColectivo;
        }

        public float getTotalAbonado()
        {
            return totalAbonado;
        }

        public float getSaldoRestante()
        {
            return saldoRestante;
        }

        public string getDescripcionExtra()
        {
            return descripcionExtra;
        }
    }

    public class Boleto_Urbano : Boleto
    {
        public Boleto_Urbano(int idBoleto, string tipoTarjeta, string lineaColectivo, float totalAbonado, float saldoRestante, bool cancelaSaldoNegativo = false)
            : base(idBoleto, tipoTarjeta, lineaColectivo, totalAbonado, saldoRestante, cancelaSaldoNegativo)
        {
            precio = 1200;
        }
    }

    public class Boleto_Larga_Distancia : Boleto
    {
        public Boleto_Larga_Distancia(int idBoleto, string tipoTarjeta, string lineaColectivo, float totalAbonado, float saldoRestante, bool cancelaSaldoNegativo = false)
            : base(idBoleto, tipoTarjeta, lineaColectivo, totalAbonado, saldoRestante, cancelaSaldoNegativo)
        {
            precio = 2500;
        }
    }
}

