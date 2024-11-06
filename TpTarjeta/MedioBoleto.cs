﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarjeta1
{
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
}
