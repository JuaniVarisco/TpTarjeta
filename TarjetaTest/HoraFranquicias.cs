/*
using ManejoDeTiempos;
using Tarjeta1;

namespace TarjetaTest
{
    public class TestHoras
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
        public void DiasTest(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjeta.cargarSaldo(9000);
            Assert.That(tarjeta.PuedeRealizarViaje(tiempo), Is.EqualTo(true));
            
        }

        [Test]
        [TestCase(940)]
        public void DiasTestNo(float tarifa)
        {
            DateTime tiempo = new DateTime(2024, 08, 23, 23, 30, 00);
            tarjeta.cargarSaldo(9000);
            Assert.That(tarjeta.PuedeRealizarViaje(tiempo), Is.EqualTo(false));

        }
    }
}
*/