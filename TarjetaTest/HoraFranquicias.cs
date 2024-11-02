using Tarjeta1;

namespace TarjetaTest
{
    public class TestHoras
    {

        public Tarjeta tarjeta;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Medio_Boleto();
        }
        
        [Test]
        [TestCase(940)]
        public void DiasTest(float tarifa)
        {
            tarjeta.cargarSaldo(9000);
            Assert.That(tarjeta.PuedeRealizarViaje(), Is.EqualTo(false));
            // segun fecha y hora local, horarios no permitidos dara false
        }
    }
}