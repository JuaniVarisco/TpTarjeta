namespace Tarjeta1
{
	public class Colectivo
	{
		private string linea = "";
		private int unidad;
		public float costo = 1200;

		
	}

	public class Urbano : Colectivo
	{
		public Urbano() 
		{
			costo = 1200;
		}
	}

	public class Larga_Distancia : Colectivo
	{
        public Larga_Distancia()
        {
            costo = 2500;
        }
    }
}
