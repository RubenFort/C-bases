using System;

namespace _02Coordenadas
{
    class Program
    {
        public class Coordenadas { public int x; public int y; }

        static void Main(string[] args)
        {
            #region tipoXValor
            bool val = false;
            bool nuevoVal = val;
            val = true;

            Console.WriteLine("val {0}", val);
            Console.WriteLine("nuevoVal {0}", nuevoVal);
            #endregion

            #region tipoXReferencia
            Coordenadas coordA = new Coordenadas();
            coordA.x = 1;
            coordA.y = 50;

            Coordenadas coordB = coordA;

            Console.WriteLine("coordA.x {0}", coordA.x);
            Console.WriteLine("coordA.y {0}", coordA.y);
            Console.WriteLine("coordB.x {0}", coordB.x);
            Console.WriteLine("coordB.y {0}", coordB.y);

            coordA.x = 100;
            Console.WriteLine("coordB.x {0}", coordB.x);
            Console.WriteLine("coordB.y {0}", coordB.y);
            #endregion

            #region keyboardRef
            int miNum = 10;
            AddTen(ref miNum);
            Console.WriteLine("miNum {0}", miNum);
            Console.ReadKey();
            #endregion
        }

        static void AddTen (ref int number)
        {
            number += 10;
        }
    }
}
