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

    // 1 - Declaro delegado
    public delegate void CambioFormaPagoHandler(TipoPago tipoPago, TipoAlerta tipoAlerta);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa una forma de pago: ");
            Console.WriteLine("1- Tarjeta \n2- Transferencia \n3- Otros ");
            string tipoPago = Console.ReadLine();
        }
    }

    public class FormaDePago // event broadcaster/emisora
    {
        private TipoPago tipo;

        // 2 - Declaro evento como miembro del delegado
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
                // 3 - Lanzar evento cuando se asigna un valor a tipo, es decir en set
                CambioFormaPago(tipo, tipoAlerta);
            }
        }
    }
}