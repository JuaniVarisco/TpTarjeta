using Tarjeta1;

namespace Tarjeta1
{
    public class Urbano : Colectivo
    {
        public Urbano(string linea1, int unidad1)
        {
            linea = linea1;
            unidad = unidad1;
            costo = 1200;
        }
    }
}
