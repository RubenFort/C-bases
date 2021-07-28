using System;
using System.Collections.Generic;
using System.Text;

namespace _03OtrosTiposDeDatos
{
    class Concatenar<T>
    {
        public string resultado;

        public void Agregar(T obj)
        {
            resultado += obj.ToString();
        }
    }
}
