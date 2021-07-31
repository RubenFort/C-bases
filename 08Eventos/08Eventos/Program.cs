using _08Eventos;
using System;

namespace _08Eventos
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

    //*********************************************************************************************************
    // 1 - Declaro delegado ***********************************************************************************
    public delegate void CambioFormaPagoHandler(TipoPago tipoPago, TipoAlerta tipoAlerta);

    class Program // Clase suscriptora
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa una forma de pago: ");
            Console.WriteLine("1- Tarjeta \n2- Transferencia \n3- Otros ");
            string tipoPago = Console.ReadLine();

            FormaDePago fm = new FormaDePago();

            //*********************************************************************************************************
            // 4 - Registro el evento *********************************************************************************
            fm.CambioFormaPago += fm_seleccionFormaPago;
            fm.CambioFormaPago += fm_continuarProcesoPago;
            fm.Tipo = (TipoPago)Enum.Parse(typeof(TipoPago), tipoPago); // Accion - Al haber agregado los métodos "fm_seleccionFormaPago" 
                                                                        // y "fm_continuarProcesoPago" el evento "CambioFormaPago", al Settear
                                                                        // Tipo se ejecutan los 2 eventos de forma síncrona (por orden, uno al acabar el otro).
            Console.ReadKey();
        }
        static void fm_seleccionFormaPago(TipoPago tipo, TipoAlerta tipoAlerta)
        {
            if (tipoAlerta.Equals(TipoAlerta.Error))
                Console.WriteLine("Error, elegiste forma de pago incorrecta");
            else if (tipoAlerta.Equals(TipoAlerta.Exito))
                Console.WriteLine("Forma de pago seleccionada: {0}", tipo.ToString()); 
        }
        
        static void fm_continuarProcesoPago(TipoPago tipo, TipoAlerta tipoAlerta)
        {
            bool status = false;

            if (tipoAlerta.Equals(TipoAlerta.Exito))
            {
                Console.WriteLine("Continuando con el proceso de pago por ", tipo.ToString());
                Console.WriteLine("Presione x para continuar..", tipo.ToString());
                string tipoPago = Console.ReadLine();
                if (tipoPago == "x")
                {
                    status = true;
                }
                Console.WriteLine("Confirmacion recibida, estatus de la operacion {0}", status ? "confirmada" : "cancelada");
            }
        }
    }

    public class FormaDePago // event broadcaster/emisora
    {
        private TipoPago tipo;

        //*********************************************************************************************************
        // 2 - Declaro evento como miembro del delegado ***********************************************************
        public event CambioFormaPagoHandler CambioFormaPago;

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

                //*********************************************************************************************************
                // 3 - Lanzar evento cuando se asigna un valor a tipo, es decir en set ************************************
                CambioFormaPago(tipo, tipoAlerta);
            }
        }
    }
}