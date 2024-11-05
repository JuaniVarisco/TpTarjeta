using ManejoDeTiempos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarjeta1;

namespace TarjetaTest
{
    public class BoletoTest
    {
        public Boleto boleto;
        public TiempoFalso tiempoFalso;


        [SetUp]
        public void Setup()
        {
            tiempoFalso = new TiempoFalso();
        }

        [Test]
        //[TestCase("Normal", "105", 940, 60, tiempoFalso)]
        public void CrearBoleto_PagoNormal_DeberiaCrearBoletoCorrectamente()
        {
            DateTime tiempo = tiempoFalso.Now();
            boleto = new Boleto(1, "Normal", "105", 940, 60, tiempo);

            // Arrange
            int idBoleto = 1;

            // Act
            //Boleto boleto = new Boleto(idBoleto, tipoTarjeta, lineaColectivo, totalAbonado, saldoRestante, tiempo);

            // Assert
            Assert.That(boleto.getIdBoleto(), Is.EqualTo(idBoleto));
            Assert.That(boleto.getTipoTarjeta(), Is.EqualTo("Normal"));
            Assert.That(boleto.getLineaColectivo(), Is.EqualTo("105"));
            Assert.That(boleto.getTotalAbonado(), Is.EqualTo(940));
            Assert.That(boleto.getSaldoRestante(), Is.EqualTo(60));
            Assert.That(boleto.getDescripcionExtra(), Is.EqualTo("Pago normal"));
        }

        [Test]
        [TestCase("Estudiante", "108", 120, 0)]
        public void CrearBoleto_CancelacionDeSaldoNegativo_DeberiaIndicarSaldoAbonado(string tipoTarjeta, string lineaColectivo, float totalAbonado, float saldoRestante)
        {
            // Arrange
            int idBoleto = 2;

            // Act
            Boleto boleto = new Boleto(idBoleto, tipoTarjeta, lineaColectivo, totalAbonado, saldoRestante, cancelaSaldoNegativo: true);

            // Assert
            Assert.That(boleto.getDescripcionExtra(), Is.EqualTo("Abona saldo 120"));
        }

        [Test]
        [TestCase("Descuento", "130", 470, 530)]
        public void CrearBoleto_TipoDeTarjetaDescuento_DeberiaCrearBoletoConDescuento(string tipoTarjeta, string lineaColectivo, float totalAbonado, float saldoRestante)
        {
            // Arrange
            int idBoleto = 3;

            // Act
            Boleto boleto = new Boleto(idBoleto, tipoTarjeta, lineaColectivo, totalAbonado, saldoRestante);

            // Assert
            Assert.That(boleto.getTotalAbonado(), Is.EqualTo(totalAbonado));
            Assert.That(boleto.getSaldoRestante(), Is.EqualTo(saldoRestante));
            Assert.That(boleto.getDescripcionExtra(), Is.EqualTo("Pago normal"));
        }
    }
}
