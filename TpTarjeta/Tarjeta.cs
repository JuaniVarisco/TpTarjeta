namespace Tarjeta1
{
    public class Tarjeta
    {
        private int id;
        public float saldo;
        public float parte = 1;
        public float excedente = 0;
        public DateTime ultimaTransaccion = DateTime.MinValue;
        public int viajesDiarios = 0;
        public int viajesMensuales = 0;


        public virtual int getId()
        {
            return id;
        }

        public float getSaldo()
        {
            return saldo;
        }

        public bool PuedeRealizarViaje(DateTime tiempo)
        {            
            if (this is Medio_Boleto && (tiempo - ultimaTransaccion).TotalMinutes < 5)
            {
                return false;
            }

            if (this is Medio_Boleto || this is Boleto_Estudiantil || this is Boleto_Jubilados)
            {
                if (!(tiempo.DayOfWeek >= DayOfWeek.Monday && tiempo.DayOfWeek <= DayOfWeek.Friday && tiempo.Hour >= 6 && tiempo.Hour <= 22)) {
                    return false;
                }
            }

            return true;
        }


        public virtual bool cobrarSaldo(float tarifa, DateTime tiempo)
        {
            if(ultimaTransaccion.Date != tiempo.Date)
            {
                viajesDiarios = 0;
            }

            if (ultimaTransaccion.Month != tiempo.Month || ultimaTransaccion.Year != tiempo.Year)
            {
                viajesMensuales = 0;
            }

            float parteEnUso = parte;

            if (tarifa * parteEnUso <= saldo + 480)
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

                ultimaTransaccion = tiempo;
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
        public Boleto_Normal()
        {
            parte = 1;
        }
        public override bool cobrarSaldo(float tarifa, DateTime tiempo)
        {
            if (ultimaTransaccion.Date != tiempo.Date)
            {
                viajesDiarios = 0;
            }

            if (ultimaTransaccion.Month != tiempo.Month || ultimaTransaccion.Year != tiempo.Year)
            {
                viajesMensuales = 0;
            }
            float parteEnUso = parte;

                if (viajesMensuales > 28)
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
            

            if (tarifa * parteEnUso <= saldo + 480 )
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

                ultimaTransaccion = tiempo;
                viajesDiarios++;
                viajesMensuales++;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class Medio_Boleto : Tarjeta
    {
        public Medio_Boleto()
        {
            parte = 0.5f;
        }
        public override bool cobrarSaldo(float tarifa, DateTime tiempo)
        {
            if (ultimaTransaccion.Date != tiempo.Date)
            {
                viajesDiarios = 0;
            }

            if (ultimaTransaccion.Month != tiempo.Month || ultimaTransaccion.Year != tiempo.Year)
            {
                viajesMensuales = 0;
            }

            float parteEnUso = (viajesDiarios < 4) ? 0.5f : 1;

            if (tarifa * parteEnUso <= saldo + 480 && (PuedeRealizarViaje(tiempo)))
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

                ultimaTransaccion = tiempo;
                viajesDiarios++;
                viajesMensuales++;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Boleto_Estudiantil : Tarjeta
    {
        public Boleto_Estudiantil()
        {
            parte = 0;
        }
        public override bool cobrarSaldo(float tarifa, DateTime tiempo)
        {
            if (ultimaTransaccion.Date != tiempo.Date)
            {
                viajesDiarios = 0;
            }

            if (ultimaTransaccion.Month != tiempo.Month || ultimaTransaccion.Year != tiempo.Year)
            {
                viajesMensuales = 0;
            }

            float parteEnUso = (viajesDiarios < 2) ? 0 : 1;


            if (tarifa * parteEnUso <= saldo + 480)
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

                ultimaTransaccion = tiempo;
                viajesDiarios++;
                viajesMensuales++;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Boleto_Jubilados : Tarjeta
    {
        public Boleto_Jubilados()
        {
            parte = 0;
        }
        public override bool cobrarSaldo(float tarifa, DateTime tiempo)
        {
            if (ultimaTransaccion.Date != tiempo.Date)
            {
                viajesDiarios = 0;
            }

            if (ultimaTransaccion.Month != tiempo.Month || ultimaTransaccion.Year != tiempo.Year)
            {
                viajesMensuales = 0;
            }

            float parteEnUso = 1;

            if (tarifa * parteEnUso <= saldo + 480 && (PuedeRealizarViaje(tiempo)))
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

                ultimaTransaccion = tiempo;
                viajesDiarios++;
                viajesMensuales++;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
