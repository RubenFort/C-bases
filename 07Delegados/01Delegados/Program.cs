using System;

namespace _01Delegados
{
    // 1 - Declaro delegado
    public delegate float CalcularTotal(float subtotal);

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

        public float CalcularMontoTotal(float importe)
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

        public float CalcularMontoTotal(float importe)
        {
            float total =  importe + (importe * Iva) + Tua;
            if (Destino == 559)
                return total + ImpuestoFederalSeguridad;
            return total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VueloNacional vueloNac = new VueloNacional(true);

            // 2 - Instacio delegado
            //CalcularTotal total = new CalcularTotal(vueloNac.CalcularMontoTotal); //Método largo
            CalcularTotal total = vueloNac.CalcularMontoTotal; //Método abreviado

            float precio = 5500f;

            // 3 - Invoco delegado
            Console.WriteLine("Importe del vuelo nacional {0}", total(precio));

            VueloInternacional vueloInter = new VueloInternacional(false, 559);
            total = vueloInter.CalcularMontoTotal;
            float vuelointernac = 9800f;
            float t = total(vuelointernac);
            Console.WriteLine("Importe del vuelo internacional sencillo {0}", t);
            
            #region parametros
            float totalAdultoMayor = CalcularConDescuentoAdultoMayor(t, total);
            Console.WriteLine("Importe del vuelo internacional sencillo con descuento adulto mayor {0}", totalAdultoMayor);
            #endregion

            Console.ReadKey();
        }
        static float CalcularConDescuentoAdultoMayor(float importe, CalcularTotal total)
        {
            float subTotal = total(importe);
            return subTotal - (0.35f * subTotal);
        }
    }
}
