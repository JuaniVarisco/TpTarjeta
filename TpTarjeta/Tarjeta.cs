namespace Tarjeta1
{
    public class Tarjeta
    {
        private int id;
        public float saldo;
        public float parte = 1;
        public float excedente = 0;
        private DateTime ultimaTransaccion;
        private int viajesDiarios = 0;


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
            if (parte == 0.5f)
            {
                if ((DateTime.Now - ultimaTransaccion).TotalMinutes < 5)
                {
                    return false;
                }
            }
            return true;
        }


        public bool cobrarSaldo(float tarifa)
        {
            if (tarifa * parte <= saldo + 480)
            {
                saldo -= tarifa * parte;
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
        public static new float parte = 1;
    }
}
