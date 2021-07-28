using System;

namespace _06Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Agencia de Venta de Vehiculos";
            Console.WriteLine("Selecciona opcion de captura: ");
            Console.WriteLine("1 Moto");
            Console.WriteLine("2 Automovil");
            Console.WriteLine("3 Camioneta Moto");

            try
            {
                int seleccion = Int32.Parse(Console.ReadLine());

                int anio, llantas, color;
                string modelo;

                switch (seleccion)
                {
                    case 1:

                        break;
                    case 2:
                        Console.WriteLine("Modelo:");
                        modelo = Console.ReadLine();
                        Console.WriteLine("Año:");
                        anio = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Llantas:");
                        llantas = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Color: 1 Blanco, 2 Gris, 3 Rojo");
                        color = Int32.Parse(Console.ReadLine());
                        Automovil miAuto = new Automovil();
                        miAuto.Id = 0;
                        miAuto.Llantas = llantas;
                        miAuto.Modelo = modelo;
                        miAuto.Anio = anio;

                        string resp = miAuto.Capturar();
                        Console.WriteLine("Respuesta: " + resp);
                        break;
                    case 3:

                        break;

                    default:

                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
            Console.ReadKey();
        }
    }
}
