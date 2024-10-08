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

        // Test cobrar saldo
        public void cobrarSaldoSinSaldoTest(float tarifa)
        {
            Tarjeta tarjeta = new Tarjeta(); // Crear la tarjeta con saldo 0
            tarjeta.saldo = 0; // Asignar saldo directamente
            Assert.That(tarjeta.cobrarSaldo(tarifa), Is.EqualTo(false));
        }

        [Test]
        [TestCase(940)]
        public void cobrarSaldoConSaldoTest(float tarifa)
        {
            Tarjeta tarjeta = new Tarjeta(); // Crear la tarjeta con saldo 0
            tarjeta.saldo = 1000; // Asignar saldo directamente
            Assert.That(tarjeta.cobrarSaldo(tarifa), Is.EqualTo(true));
        }

        // 
        [Test]
        [TestCase(460)]
        [TestCase(459)]
        public void verificarSaldoMinimo(float saldo)
        {
            Tarjeta tarjeta = new Tarjeta(); // Crear la tarjeta con saldo 0
            tarjeta.saldo = saldo; // Asignar saldo directamente
            Assert.That(tarjeta.cobrarSaldo(940), Is.EqualTo(true));
        }

        // caso en que el saldo es -480 (la maxima deuda permitida)
        [Test]
        [TestCase(2000)]
        public void verificarCobro(int carga)
        {
            Tarjeta tarjeta = new Tarjeta(); // Crear la tarjeta con saldo 0
            tarjeta.saldo = 460; // Asignar saldo directamente
            Assert.That(tarjeta.cobrarSaldo(940), Is.EqualTo(true));
            Assert.That(tarjeta.cargarSaldo(carga), Is.EqualTo(true));
            Assert.That(tarjeta.getSaldo, Is.EqualTo(1520));
        }

        // Faltan los tests de franquicia de boleto
    }
}