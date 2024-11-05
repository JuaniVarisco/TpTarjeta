using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeTiempos
{
    public class TiempoFalso
    {
        private DateTime tiempo;

        public TiempoFalso()
        {
            tiempo = new DateTime(2024, 08, 23, 16, 30, 00);
        }

        public DateTime Now()
        {
            return tiempo;
        }

        public void AgregarDias(int cantidad)
        {
            tiempo = tiempo.AddDays(cantidad);
        }

        public void AgregarMinutos(int cantidad)
        {
            tiempo = tiempo.AddMinutes(cantidad);
        }

        public void CambiarTiempo(DateTime tiempoNuevo)
        {
            tiempo = tiempoNuevo;
        }
    }
}