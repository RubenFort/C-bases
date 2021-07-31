 using System;

namespace _10Tuplas
{
    class Program
    {
        static void Main(string[] args)
        {
            var proveedor1 = ("Pepe", "Vara", 33);
            Console.WriteLine($"Proveedor: {proveedor1.Item1}, {proveedor1.Item2}, {proveedor1.Item3}");
            
            var proveedor2 = (Nombre: "Pepe", Apellido: "Vara", Edad: 33);
            Console.WriteLine($"Edad del proveedor2: {proveedor2.Edad}");

            (string Nombre, string Apellido) miTupla = (Nombre: "Pepe", Apellido: "Vara");
            Console.WriteLine($"miTupla Nombre: {miTupla.Nombre}");

            miTupla.Nombre = "Juan";
            Console.WriteLine($"miTupla Nombre: {miTupla.Nombre}");

            Console.ReadKey();
        }
    }
}
