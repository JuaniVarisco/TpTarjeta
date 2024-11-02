using Tarjeta1;

namespace TarjetaTest
{
    public class TestDias
    {

        public Tarjeta tarjeta;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Medio_Boleto();
        }
        // notese que se debe esperar entre cobros pero esa funcionalidad ya fue revisada y testeada
        [Test]
        [TestCase(940)]
        public void DiasTest(float tarifa)
        {
            tarjeta.cargarSaldo(9000);
            tarjeta.cobrarSaldo(tarifa);
            tarjeta.cobrarSaldo(tarifa);
            tarjeta.cobrarSaldo(tarifa);
            tarjeta.cobrarSaldo(tarifa);
            Assert.That(tarjeta.getSaldo() == (9000 - 470*4), Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]
        public void NoDiasTest(float tarifa)
        {
            tarjeta.cargarSaldo(9000);
            tarjeta.cobrarSaldo(tarifa);
            tarjeta.cobrarSaldo(tarifa);
            tarjeta.cobrarSaldo(tarifa);
            tarjeta.cobrarSaldo(tarifa);
            tarjeta.cobrarSaldo(tarifa);
            Assert.That(tarjeta.getSaldo() == (9000 - 470*4 - 940), Is.EqualTo(true));
        }
    }
}