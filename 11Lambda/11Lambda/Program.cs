using System;

namespace _11Lambda
{
    delegate int Operacion (int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            Operacion op = (a, b) => a * b;
            var resultado = op(2, 3);
            Console.WriteLine($"Total: {resultado}");

            Operacion potencia = (a, b) =>
            {
                Console.WriteLine($"{a} elevado a la {b} potencia");
                return (int)Math.Pow(a, b);
            };

            int n1 = 2;
            int n2 = 4;
            int resultadoPot = potencia(n1, n2);
            Console.WriteLine($"Total: {resultadoPot}");

            Func<int, int, int> pot = (x, y) => (int)Math.Pow(x, y);
            Console.WriteLine($"Total: {pot(5, 5)}");

            //Func(recibe, recibe, return)
            Func<string, string, bool> igual = (strA, strB) => strA.Equals(strB);
            string cadA = "Noemi";
            string cadB = "noemi";
            Console.WriteLine($"Son iguales? {igual(cadA, cadB)}");

            Console.ReadKey();
        }
    }
}
