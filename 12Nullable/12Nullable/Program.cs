using System;

namespace _12Nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            int? x = 5;
            int? y = null;

            if (x.Equals(y))
                Console.WriteLine($"{x} y {y} son iguales");
            else
                Console.WriteLine($"{x} y {y} no son iguales");

            Console.WriteLine(y.GetValueOrDefault());

            //operador ??
            int? g = null;
            int h = g ?? 1; // si g es null, h es igual a 1
            Console.WriteLine(h.ToString());
            Console.WriteLine(g.ToString());

            bool mayor = x > y;
            Console.WriteLine($"x es mayor que y?  {mayor}");

            if (x.HasValue)
                Console.WriteLine($"x = {x}");
            else
                Console.WriteLine($"x es nulo");

            Console.ReadKey();
        }
    }
}
