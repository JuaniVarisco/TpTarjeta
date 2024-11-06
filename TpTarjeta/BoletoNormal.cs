﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarjeta1
{
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
}
