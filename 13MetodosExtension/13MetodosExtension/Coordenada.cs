﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13MetodosExtension
{
    public static class Coordenada
    {
        public static List<int> ObtenerInverso(this List<int> inicial)
        {
            List<int> final = new List<int>();
            foreach (int c in inicial)
            {
                final.Add(-c);
            }
            return final;
        }

        public static List<int> MoverACuadrante(this List<int> inicial, int cuadrante)
        {
            int x, y;
            x = Math.Abs(inicial.First());
            y = Math.Abs(inicial.Last());

            switch (cuadrante)
            {
                case 2:
                    x = -x;
                    break;
                case 3:
                    x = -x;
                    y = -y;
                    break;
                case 4:
                    y = -y;
                    break;
            }
            return new List<int>() { x, y };
        }
    }
}
