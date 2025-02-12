﻿using System;
namespace _09EventHandlersEn.NET
{
    public enum TipoAlerta
    {
        Error = 1,
        Advertencia = 2,
        Exito = 3
    }

    public enum TipoPago
    {
        Tarjeta = 1,
        Transferencia = 2,
        Otros = 3
    }

    class Program // Clase suscriptora
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa una forma de pago: ");
            Console.WriteLine("1- Tarjeta \n2- Transferencia \n3- Otros ");
            string tipoPago = Console.ReadLine();

            FormaDePago fm = new FormaDePago();

            fm.CambioFormaPago += fm_seleccionFormaPago;
            fm.Tipo = (TipoPago)Enum.Parse(typeof(TipoPago), tipoPago); // Accion - Al haber agregado los métodos "fm_seleccionFormaPago" 
                                                                        // y "fm_continuarProcesoPago" el evento "CambioFormaPago", al Settear
                                                                        // Tipo se ejecutan los 2 eventos de forma síncrona (por orden, uno al acabar el otro).
            Console.ReadKey();
        }
        static void fm_seleccionFormaPago(object emisor, CambioFormaPagoEventArgs args)
        {
            if (args.TipoAlerta.Equals(TipoAlerta.Error))
                Console.WriteLine("Error, elegiste forma de pago incorrecta");
            else if (args.TipoAlerta.Equals(TipoAlerta.Exito))
                Console.WriteLine("Forma de pago seleccionada: {0}", args.TipoPago.ToString());
        }
    }

    public class FormaDePago // event broadcaster/emisora
    {
        private TipoPago tipo;

        public event EventHandler<CambioFormaPagoEventArgs> CambioFormaPago;

        public TipoPago Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                TipoAlerta tipoAlerta = TipoAlerta.Error;
                if (value.Equals(TipoPago.Tarjeta)
                    || value.Equals(TipoPago.Transferencia)
                    || value.Equals(TipoPago.Otros))
                {
                    tipo = value;
                    tipoAlerta = TipoAlerta.Exito;
                }

                CambioFormaPagoEventArgs args = new CambioFormaPagoEventArgs
                {
                    TipoPago = tipo,
                    TipoAlerta = tipoAlerta
                };
                CambioFormaPago(this, args);
            }
        }
    }

    public class CambioFormaPagoEventArgs : EventArgs
    {
        public TipoAlerta TipoAlerta { get; set; }
        public TipoPago TipoPago { get; set; }
    }
}
