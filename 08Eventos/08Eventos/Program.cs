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

            fm.Tipo = (TipoPago)Enum.Parse(typeof(TipoPago), tipoPago);

            Console.ReadKey();
        }
        static void fm_seleccionFormaPago(TipoPago tipo, TipoAlerta tipoAlerta)
        {
            if (tipoAlerta.Equals(TipoAlerta.Error))
                Console.WriteLine("Error, elegiste forma de pago incorrecta");
            else if (tipoAlerta.Equals(TipoAlerta.Exito))
                Console.WriteLine("Forma de pago seleccionada: {0}", tipo.ToString()); 
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