/*
using ManejoDeTiempos;
using Tarjeta1;

namespace TarjetaTest
{
    public class TestDias
    {

        public Tarjeta tarjeta;
        public TiempoFalso tiempoFalso;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Medio_Boleto();
            tiempoFalso = new TiempoFalso();
        }
        // notese que se debe esperar entre cobros pero esa funcionalidad ya fue revisada y testeada
        [Test]
        [TestCase(940)]
        public void DiasTest(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjeta.cargarSaldo(9000);
            tarjeta.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjeta.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjeta.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjeta.cobrarSaldo(tarifa, tiempo);
            Assert.That(tarjeta.getSaldo() == (9000 - 470*4), Is.EqualTo(true));
        }

        [Test]
        [TestCase(940)]
        public void NoDiasTest(float tarifa)
        {
            DateTime tiempo = tiempoFalso.Now();
            tarjeta.cargarSaldo(9000);
            tarjeta.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjeta.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjeta.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjeta.cobrarSaldo(tarifa, tiempo);
            tiempoFalso.AgregarMinutos(5);
            tiempo = tiempoFalso.Now();
            tarjeta.cobrarSaldo(tarifa, tiempo);
            Assert.That(tarjeta.getSaldo() == (9000 - 470*4 - 940), Is.EqualTo(true));
        }
    }
}
*/