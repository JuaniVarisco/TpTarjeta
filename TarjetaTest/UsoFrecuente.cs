
using ManejoDeTiempos;
using Tarjeta1;

namespace TarjetaTest
{
    public class TestUsoFrecuente
    {

        public Tarjeta tarjeta;
        public TiempoFalso tiempoFalso;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Boleto_Normal();
            tiempoFalso = new TiempoFalso();
        }
        [Test]
        [TestCase(100)]
        public void LimiteUno(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjeta.cargarSaldo(9000);
            for (int i = 0; i < 29; i++)
            {
                tarjeta.cobrarSaldo(tarifa, tiempo);
            } // viaje 29
            Assert.That(tarjeta.getSaldo() == (9000 - 100*29), Is.EqualTo(true));

            tarjeta.cobrarSaldo(tarifa, tiempo); //viaje 30
            Assert.That(tarjeta.getSaldo() == (9000 - 100 * 29 - 80), Is.EqualTo(true));
            
            for (int i = 0; i < 49; i++)
            {
                tarjeta.cobrarSaldo(tarifa, tiempo);
            }
            // viaje 79
            Assert.That(tarjeta.getSaldo() == (9000 - 100 * 29 - 80 * 50), Is.EqualTo(true));
            
            tarjeta.cobrarSaldo(tarifa, tiempo); // viaje 80
            Assert.That(tarjeta.getSaldo() == (9000 - 100 * 29 - 80 * 50 - 75), Is.EqualTo(true));
            
            tarjeta.cobrarSaldo(tarifa, tiempo); // viaje 81
            Assert.That(tarjeta.getSaldo() == (9000 - 100 * 29 - 80 * 50 - 75 - 100), Is.EqualTo(true));
            
        }
    }
}
