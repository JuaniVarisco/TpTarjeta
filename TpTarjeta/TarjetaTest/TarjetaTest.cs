using Tarjeta1;

namespace TarjetaTest
{
    public class TarjetaTest
    {

        public Tarjeta tarjeta;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta();
        }

        [Test]
        [TestCase(2000)]
        [TestCase(3000)]
        [TestCase(4000)]
        [TestCase(9000)]
        public void CargarSaldoTest(int carga)
        {
            Assert.That(tarjeta.cargarSaldo(carga), Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]
        public void cobrarSaldoTest(float tarifa)
        {
            Assert.That(tarjeta.cobrarSaldo(tarifa, 0), Is.EqualTo(true));
        }
    }
}