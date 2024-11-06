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

        public Boleto(int idBoleto, string tipoTarjeta, string lineaColectivo, float totalAbonado, float saldoRestante, DateTime tiempo, bool cancelaSaldoNegativo = false)
        {
            this.idBoleto = idBoleto;
            this.tipoTarjeta = tipoTarjeta;
            this.lineaColectivo = lineaColectivo;
            this.totalAbonado = totalAbonado;
            this.saldoRestante = saldoRestante;
            this.fecha = tiempo;
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
}