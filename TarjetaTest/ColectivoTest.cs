using ManejoDeTiempos;
using Tarjeta1;

namespace TarjetaTest
{
    public class TestTiposBoletos
    {
        public Boleto boletou;
        public Boleto boletol;
        public TiempoFalso tiempoFalso;

        [SetUp]
        public void Setup()
        {
            int idBoleto = 1234;
            string tipoTarjeta = "Estudiante";
            string lineaColectivo = "Línea 45";
            float totalAbonado = 0;
            float saldoRestante = 3500.0f;
            bool cancelaSaldoNegativo = true;

            tiempoFalso = new TiempoFalso();
            DateTime tiempo = tiempoFalso.Now();

            boletou = new Boleto_Urbano(idBoleto, tipoTarjeta, lineaColectivo, totalAbonado, saldoRestante, tiempo, cancelaSaldoNegativo);
            boletol = new Boleto_Larga_Distancia(idBoleto, tipoTarjeta, lineaColectivo, totalAbonado, saldoRestante, tiempo, cancelaSaldoNegativo);
        }

        [Test]
        public void Urbano()
        {
            Assert.That(boletou.getPrecio(), Is.EqualTo(1200));
        }

        [Test]
        public void LargaDistancia()
        {
            Assert.That(boletol.getPrecio(), Is.EqualTo(2500));
        }
    }
}
