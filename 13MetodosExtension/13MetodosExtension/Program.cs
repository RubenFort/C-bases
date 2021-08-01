using System;
using System.Collections.Generic;
using System.Linq;

namespace _13MetodosExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            #region linq
            int?[] miArr = { 10, 100, null, 500, 50, null };
            var res = miArr.Sum(e => e);
            Console.WriteLine(res);
            #endregion

            #region personalizado
            var coord = new List<int>() { 5, -9 };
            var inverso = coord.ObtenerInverso();
            Console.WriteLine($"Inverso de {coord.First()}, {coord.Last()} = {inverso.First()}, {inverso.Last()}");

            var nuevaCoord = coord.MoverACuadrante(3);
            Console.WriteLine($"Nuevas coordenandas: {nuevaCoord.First()}, {nuevaCoord.Last()}");
            #endregion

            Console.ReadKey();
        }
    }
}
