using Tarjeta1;

namespace TarjetaTest
{
    public class TestEstudiantil
    {

        public Tarjeta tarjeta;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Boleto_Estudiantil();
        }
        [Test]
        [TestCase(940)]
        public void VaDiasTest(float tarifa)
        {
            tarjeta.cargarSaldo(9000);
            tarjeta.cobrarSaldo(tarifa);
            tarjeta.cobrarSaldo(tarifa);
            Assert.That(tarjeta.getSaldo() == 9000, Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]
        public void InDiasTest(float tarifa)
        {
            tarjeta.cargarSaldo(9000);
            tarjeta.cobrarSaldo(tarifa);
            tarjeta.cobrarSaldo(tarifa);
            tarjeta.cobrarSaldo(tarifa);
            Assert.That(tarjeta.getSaldo() == (9000 - 940), Is.EqualTo(true));
        }
    }
}
