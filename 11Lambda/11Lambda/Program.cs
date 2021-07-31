using System;

namespace _11Lambda
{
    delegate int Operacion (int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            #region lambda
            Operacion op = (c, b) => c * b;
            var resultado = op(2, 3);
            Console.WriteLine($"Total: {resultado}");

            Operacion potencia = (c, b) =>
            {
                Console.WriteLine($"{c} elevado a la {b} potencia");
                return (int)Math.Pow(c, b);
            };

            int n1 = 2;
            int n2 = 4;
            int resultadoPot = potencia(n1, n2);
            Console.WriteLine($"Total: {resultadoPot}");

            Func<int, int, int> pot = (v, y) => (int)Math.Pow(v, y);
            Console.WriteLine($"Total: {pot(5, 5)}");

            //Func(recibe, recibe, return)
            Func<string, string, bool> igual = (strA, strB) => strA.Equals(strB);
            string cadA = "Noemi";
            string cadB = "noemi";
            Console.WriteLine($"Son iguales? {igual(cadA, cadB)}");
            #endregion

            #region variables e iteraciones
            int x = 2;
            int a = 5;
            Func<int, int> suma = s => x + a;
            a = 10;
            Console.WriteLine($"Suma: {suma(2)}");


            Func<int, int, int> potB = (z, y) => (int)Math.Pow(z, y);
            int baseP = 5;
            for (int i = 1; i <= 3; i++)
            {
                int res = potB(baseP, i);
                Console.WriteLine($"{baseP} elevado a la {i} potencia = {res}");
            }

            Console.ReadKey();
            #endregion

            Console.ReadKey();
        }
    }
}
