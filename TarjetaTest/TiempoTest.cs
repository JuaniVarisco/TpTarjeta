using Tarjeta1;

namespace TarjetaTest
{
    public class TiempoTest
    {

        public Tarjeta tarjeta;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Medio_Boleto();
        }

        [Test]
        [TestCase(940)]
        public void VerTiempoTest(float tarifa)
        {
            tarjeta.cargarSaldo(9000);
            Assert.That(tarjeta.cobrarSaldo(tarifa), Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]
        public void EsperarTiempoTest(float tarifa)
        {
            tarjeta.cargarSaldo(9000);
            tarjeta.cobrarSaldo(tarifa);
            Thread.Sleep(TimeSpan.FromMinutes(6));
            Assert.That(tarjeta.cobrarSaldo(tarifa), Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]
        public void MalTiempoTest(float tarifa)
        {
            tarjeta.cargarSaldo(9000);
            tarjeta.cobrarSaldo(tarifa);
            Thread.Sleep(TimeSpan.FromMinutes(3));
            Assert.That(tarjeta.PuedeRealizarViaje(), Is.EqualTo(false));
        }

    }
}