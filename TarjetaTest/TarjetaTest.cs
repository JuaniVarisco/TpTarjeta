using Tarjeta1;
using ManejoDeTiempos;

namespace TarjetaTest
{
    public class TarjetaTest
    {

        public Tarjeta tarjeta;
        public TiempoFalso tiempoFalso;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta();
            tiempoFalso = new TiempoFalso();
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
            DateTime tiempo = tiempoFalso.Now();
            Tarjeta tarjeta = new Tarjeta(); // Crear la tarjeta con saldo 0
            tarjeta.saldo = 0; // Asignar saldo directamente
            Assert.That(tarjeta.cobrarSaldo(tarifa, tiempo), Is.EqualTo(false));
        }

        [Test]
        [TestCase(940)]
        public void cobrarSaldoConSaldoTest(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            Tarjeta tarjeta = new Tarjeta(); // Crear la tarjeta con saldo 0
            tarjeta.saldo = 1000; // Asignar saldo directamente
            Assert.That(tarjeta.cobrarSaldo(tarifa, tiempo), Is.EqualTo(true));
        }

        [Test]
        [TestCase(460)]
        // cambiar esto y ponerlo dentro del test los 2 casos
        public void verificarSaldoMinimo(float saldo)
        {
            DateTime tiempo = tiempoFalso.Now();
            Tarjeta tarjeta = new Tarjeta(); // Crear la tarjeta con saldo 0
            tarjeta.saldo = saldo; // Asignar saldo directamente
            Assert.That(tarjeta.cobrarSaldo(940, tiempo), Is.EqualTo(true));
        }
        [Test]
        [TestCase(459)] // cambiar esto y ponerlo dentro del test los 2 casos
        public void verificarSaldoMinimoo(float saldo)
        {
            DateTime tiempo = tiempoFalso.Now();
            Tarjeta tarjeta = new Tarjeta(); // Crear la tarjeta con saldo 0
            tarjeta.saldo = saldo; // Asignar saldo directamente
            Assert.That(tarjeta.cobrarSaldo(940, tiempo), Is.EqualTo(false));
        }

        // caso en que el saldo es -480 (la maxima deuda permitida)
        [Test]
        [TestCase(2000)]
        public void verificarCobro(int carga)
        {
            DateTime tiempo = tiempoFalso.Now();
            Tarjeta tarjeta = new Tarjeta(); // Crear la tarjeta con saldo 0
            tarjeta.saldo = 460; // Asignar saldo directamente
            Assert.That(tarjeta.cobrarSaldo(940, tiempo), Is.EqualTo(true));
            Assert.That(tarjeta.cargarSaldo(carga), Is.EqualTo(true));
            Assert.That(tarjeta.getSaldo, Is.EqualTo(1520));
        }

        // tests de franquicia de boleto
        [Test]
        [TestCase(940)]

        public void cobrarfranquicia(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            Tarjeta tarjeta = new Boleto_Jubilados(); // Crear la tarjeta con saldo 0
            tarjeta.cargarSaldo(9000); // Asignar saldo directamente
            Assert.That(tarjeta.cobrarSaldo(tarifa, tiempo), Is.EqualTo(true));
            Assert.That(tarjeta.getSaldo() == 9000, Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]

        public void cobrarfranquiciaa(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            Tarjeta tarjeta = new Boleto_Estudiantil(); // Crear la tarjeta con saldo 0
            tarjeta.cargarSaldo(9000); // Asignar saldo directamente
            Assert.That(tarjeta.cobrarSaldo(tarifa, tiempo), Is.EqualTo(true));
            Assert.That(tarjeta.getSaldo() == 9000, Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]

        public void cobrarmedio(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            Tarjeta tarjeta = new Medio_Boleto(); // Crear la tarjeta con saldo 0
            tarjeta.cargarSaldo(9000); // Asignar saldo directamente
            Assert.That(tarjeta.cobrarSaldo(tarifa, tiempo), Is.EqualTo(true));
            Assert.That(tarjeta.getSaldo() == (9000 - 470), Is.EqualTo(true));
        }
    }
}