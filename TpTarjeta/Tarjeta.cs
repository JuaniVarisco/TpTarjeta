namespace Tarjeta1
{
    public class Tarjeta
    {
        private int id;
        public float saldo;
        public float parte = 1;
        public float excedente = 0;
        private DateTime ultimaTransaccion = DateTime.MinValue;
        private int viajesDiarios = 0;
        private int viajesMensuales = 0;


        public int getId()
        {
            return id;
        }

        public float getSaldo()
        {
            return saldo;
        }

        public bool PuedeRealizarViaje()
        {            
            if (this is Medio_Boleto && (DateTime.Now - ultimaTransaccion).TotalMinutes < 5)
            {
                return false;
            }
            return true;
        }


        public bool cobrarSaldo(float tarifa)
        {
            if(ultimaTransaccion.Date != DateTime.Now.Date)
            {
                viajesDiarios = 0;
            }

            if (ultimaTransaccion.Month != DateTime.Now.Month || ultimaTransaccion.Year != DateTime.Now.Year)
            {
                viajesMensuales = 0;
            }

            float parteEnUso = (viajesDiarios < 4 && this is Medio_Boleto) ? 0.5f : 1;
            parteEnUso = (viajesDiarios < 2 && this is Boleto_Estudiantil) ? 0 : parteEnUso;
            parteEnUso = (this is Boleto_Jubilados) ? 0 : parteEnUso;

            if(this is Boleto_Normal)
            {
                if(viajesMensuales > 28)
                {
                    parteEnUso = 0.8f;
                }
                if (viajesMensuales > 78)
                {
                    parteEnUso = 0.75f;
                }
                if (viajesMensuales > 79)
                {
                    parteEnUso = 1;
                }
            }

            if (tarifa * parteEnUso <= saldo + 480 && (PuedeRealizarViaje() || !(this is Medio_Boleto)))
            {
                saldo -= tarifa * parteEnUso;
                if (saldo + excedente <= 66000)
                {
                    saldo = saldo + excedente;
                    excedente = 0;
                }
                else
                {
                    excedente = excedente + saldo - 66000;
                    saldo = 66000;
                }

                ultimaTransaccion = DateTime.Now;
                viajesDiarios++;
                viajesMensuales++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool cargarSaldo(float carga)
        {
            if ((carga == 2000 || carga == 3000 || carga == 4000 || carga == 5000 || carga == 6000 || carga == 7000 || carga == 8000 || carga == 9000) && (saldo + carga) <= 9900)
            {
                if (saldo + carga <= 66000)
                {
                    saldo += carga;
                    return true;
                }
                else
                {
                    excedente = excedente + saldo + carga - 66000;
                    saldo = 66000;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }

    public class Boleto_Normal : Tarjeta
    {
        public static new float parte = 1;
    }
    public class Medio_Boleto : Tarjeta
    {
        public static new float parte = 0.5f;
    }

    public class Boleto_Estudiantil : Tarjeta
    {
        public static new float parte = 0;
    }

    public class Boleto_Jubilados : Tarjeta
    {
        public static new float parte = 0;
    }
}

// hola
