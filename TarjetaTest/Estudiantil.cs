/*
using ManejoDeTiempos;
using Tarjeta1;

namespace TarjetaTest
{
    public class TestEstudiantil
    {

        public Tarjeta tarjeta;
        public TiempoFalso tiempoFalso;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Boleto_Estudiantil();
            tiempoFalso = new TiempoFalso();
        }
        [Test]
        [TestCase(940)]
        public void VaDiasTest(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjeta.cargarSaldo(9000);
            tarjeta.cobrarSaldo(tarifa, tiempo);
            tarjeta.cobrarSaldo(tarifa, tiempo);
            Assert.That(tarjeta.getSaldo() == 9000, Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]
        public void InDiasTest(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjeta.cargarSaldo(9000);
            tarjeta.cobrarSaldo(tarifa, tiempo);
            tarjeta.cobrarSaldo(tarifa, tiempo);
            tarjeta.cobrarSaldo(tarifa, tiempo);
            Assert.That(tarjeta.getSaldo() == (9000 - 940), Is.EqualTo(true));
        }
    }
}
*/