using ManejoDeTiempos;
using Tarjeta1;

namespace TarjetaTest
{
    public class TiempoTest
    {

        public Tarjeta tarjeta;
        public TiempoFalso tiempoFalso;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Medio_Boleto();
            tiempoFalso = new TiempoFalso();
        }

        [Test]
        [TestCase(940)]
        public void VerTiempoTest(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjeta.cargarSaldo(9000);
            Assert.That(tarjeta.cobrarSaldo(tarifa, tiempo), Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]
        public void EsperarTiempoTest(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjeta.cargarSaldo(9000);
            tarjeta.cobrarSaldo(tarifa, tiempo);
            //Thread.Sleep(TimeSpan.FromMinutes(6));
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            Assert.That(tarjeta.cobrarSaldo(tarifa, tiempo), Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]
        public void MalTiempoTest(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjeta.cargarSaldo(9000);
            tarjeta.cobrarSaldo(tarifa, tiempo);
            //Thread.Sleep(TimeSpan.FromMinutes(3));
            tiempoFalso.AgregarMinutos(3);
            tiempo = tiempoFalso.Now();
            Assert.That(tarjeta.PuedeRealizarViaje(tiempo), Is.EqualTo(false));
        }

    }
}