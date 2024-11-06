using Tarjeta1;
using ManejoDeTiempos;

namespace TarjetaTest
{
    public class TarjetaTest
    {

        public Tarjeta tarjeta;
        public Tarjeta tarjetaEstudiantil;
        public Tarjeta tarjetaMedioBoleto;
        public Tarjeta tarjetaNormal;

        public TiempoFalso tiempoFalso;


        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta();
            tiempoFalso = new TiempoFalso();

            // Estudiantil
            tarjetaEstudiantil = new Boleto_Estudiantil();

            // Medio boleto
            tarjetaMedioBoleto = new Medio_Boleto();

            tarjetaNormal = new Boleto_Normal();
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

        // TEST 4/5 VIAJES MEDIO BOLETO . ITERACION 3 -----------------------------------------------------------------
        
        [Test]
        [TestCase(940)]
        public void DiasTest1(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjetaMedioBoleto.cargarSaldo(9000);
            tarjetaMedioBoleto.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjetaMedioBoleto.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjetaMedioBoleto.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjetaMedioBoleto.cobrarSaldo(tarifa, tiempo);
            Assert.That(tarjetaMedioBoleto.getSaldo() == (9000 - 470 * 4), Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]
        public void NoDiasTest(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjetaMedioBoleto.cargarSaldo(9000);
            tarjetaMedioBoleto.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjetaMedioBoleto.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjetaMedioBoleto.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjetaMedioBoleto.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjetaMedioBoleto.cobrarSaldo(tarifa, tiempo);
            Assert.That(tarjetaMedioBoleto.getSaldo() == (9000 - 470 * 4 - 940), Is.EqualTo(true));
        }

        // TEST ESTUDIANTIL . ITERACION 3 -----------------------------------------------------------------
        [Test]
        [TestCase(940)]
        public void VaDiasTest(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjetaEstudiantil.cargarSaldo(9000);
            tarjetaEstudiantil.cobrarSaldo(tarifa, tiempo);
            tarjetaEstudiantil.cobrarSaldo(tarifa, tiempo);
            Assert.That(tarjetaEstudiantil.getSaldo() == 9000, Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]
        public void InDiasTest(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjetaEstudiantil.cargarSaldo(9000);
            tarjetaEstudiantil.cobrarSaldo(tarifa, tiempo);
            tarjetaEstudiantil.cobrarSaldo(tarifa, tiempo);
            tarjetaEstudiantil.cobrarSaldo(tarifa, tiempo);
            Assert.That(tarjetaEstudiantil.getSaldo() == (9000 - 940), Is.EqualTo(true));
        }

        // TEST DE USO FRECUENTE . ITERACION 4 -----------------------------------------------------------------
        [Test]
        [TestCase(100)]
        public void LimiteUno(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjetaNormal.cargarSaldo(9000);
            for (int i = 0; i < 29; i++)
            {
                tarjetaNormal.cobrarSaldo(tarifa, tiempo);
            } // viaje 29
            Assert.That(tarjetaNormal.getSaldo() == (9000 - 100 * 29), Is.EqualTo(true));

            tarjetaNormal.cobrarSaldo(tarifa, tiempo); //viaje 30
            Assert.That(tarjetaNormal.getSaldo() == (9000 - 100 * 29 - 80), Is.EqualTo(true));

            for (int i = 0; i < 49; i++)
            {
                tarjetaNormal.cobrarSaldo(tarifa, tiempo);
            }
            // viaje 79
            Assert.That(tarjetaNormal.getSaldo() == (9000 - 100 * 29 - 80 * 50), Is.EqualTo(true));

            tarjetaNormal.cobrarSaldo(tarifa, tiempo); // viaje 80
            Assert.That(tarjetaNormal.getSaldo() == (9000 - 100 * 29 - 80 * 50 - 75), Is.EqualTo(true));

            tarjetaNormal.cobrarSaldo(tarifa, tiempo); // viaje 81
            Assert.That(tarjetaNormal.getSaldo() == (9000 - 100 * 29 - 80 * 50 - 75 - 100), Is.EqualTo(true));

        }

        // TEST HORARIOS FRANQUICIAS . ITERACION 4 -----------------------------------------------------------------
        [Test]
        [TestCase(940)]
        public void DiasTest2(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjetaMedioBoleto.cargarSaldo(9000);
            Assert.That(tarjetaMedioBoleto.PuedeRealizarViaje(tiempo), Is.EqualTo(true));

        }

        [Test]
        [TestCase(940)]
        public void DiasTestNo(float tarifa)
        {
            DateTime tiempo = new DateTime(2024, 08, 23, 23, 30, 00);
            tarjetaMedioBoleto.cargarSaldo(9000);
            Assert.That(tarjetaMedioBoleto.PuedeRealizarViaje(tiempo), Is.EqualTo(false));

        }
    }
}