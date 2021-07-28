using System;

namespace _01Delegados
{
    // 1 - Declaro delegado
    public delegate float CalcularTotal(float subtotal);
    public delegate void CalcularTotalRef(ref float subTotal);
    public delegate void ImprimirMensaje(string msj);

    class VueloNacional
    {
        public VueloNacional(bool redondo)
        {
            Redondo = redondo;
        }

        float Iva
        {
            get
            {
                if (Redondo)
                    return 0.16f;
                return 0.04f;
            }
        }

        float Tua
        {
            get
            {
                return 220f;
            }
        }

        public bool Redondo { get; set; }

        public float CalcularImporteTotal(float importe)
        {
            return importe + (importe * Iva) + Tua;
        }
    }

    class VueloInternacional
    {
        float Iva
        {
            get
            {
                if (Redondo)
                    return 0.16f;
                return 0.04f;
            }
        }

        float Tua
        {
            get
            {
                return 360f;
            }
        }

        float ImpuestoFederalSeguridad
        {
            get
            {
                return 190.75f;
            }
        }

        public bool Redondo { get; set; }

        public int Destino { get; set; }

        public VueloInternacional(bool redondo, int destino)
        {
            Redondo = redondo;
            Destino = destino;
        }

        public float CalcularImporteTotal(float importe)
        {
            float total =  importe + (importe * Iva) + Tua;
            if (Destino == 559)
                return total + ImpuestoFederalSeguridad;
            return total;
        }

        public void CalcularTotalConImpuestos(ref float importe)
        {
            float total = importe + (importe * Iva) + Tua;
            if (Destino == 559)
                total += ImpuestoFederalSeguridad;
            importe = total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VueloNacional vueloNac = new VueloNacional(true);

            // 2 - Instacio delegado
            //CalcularTotal total = new CalcularTotal(vueloNac.CalcularMontoTotal); //Método largo
            CalcularTotal total = vueloNac.CalcularImporteTotal; //Método abreviado

            float precio = 5500f;

            // 3 - Invoco delegado
            Console.WriteLine("Importe del vuelo nacional {0}", total(precio));

            VueloInternacional vueloInter = new VueloInternacional(false, 559);
            total = vueloInter.CalcularImporteTotal;
            float vuelointernac = 9800f;
            float t = total(vuelointernac);
            Console.WriteLine("Importe del vuelo internacional sencillo {0}", t);
            
            #region parametros

            // Paso delegado como parametro
            float totalAdultoMayor = CalcularConDescuentoAdultoMayor(t, total);
            Console.WriteLine("Importe del vuelo internacional sencillo con descuento adulto mayor {0}", totalAdultoMayor);

            #endregion

            #region multicast

            CalcularTotal totalB = vueloInter.CalcularImporteTotal;
            totalB += CalcularTotalSeguro;
            Console.WriteLine("Importe del seguro del vuelo internacional sencillo {0}", totalB(vuelointernac)); // El delegado usa el último método agregado, en este caso CalcularTotalSeguro

            CalcularTotalRef tr = vueloInter.CalcularTotalConImpuestos;
            tr += CalcularTotalConSeguroRef;
            tr(ref vuelointernac );
            Console.WriteLine("Importe del vuelo internacional sencillo con seguro {0}", vuelointernac);

            #endregion

            #region anónimo

            ImprimirMensaje im = delegate (string mensaje)
            {
                Console.WriteLine("Mensaje {0}", mensaje);
            };
            im("Delegado anonimo");

            #endregion

            Console.ReadKey();
        }
        static float CalcularConDescuentoAdultoMayor(float importe, CalcularTotal total)
        {
            float subTotal = total(importe);
            return subTotal - (0.35f * subTotal);
        }

        static float CalcularTotalSeguro(float importeTotal)
        {
            return importeTotal * 0.1f;
        }

        static void CalcularTotalConSeguroRef (ref float total)
        {
            float porcentajeSeguro = 0.1f;
            total += total * porcentajeSeguro;
        }
    }
}
