using System;
using System.Collections.Generic;
using System.Text;

namespace _06Class
{
    class Automovil : Vehiculo
    {
        #region Atributos
        int puertas;
        #endregion

        #region Constructor
        public Automovil()
        {
            puertas = 4;
        }

        public Automovil(int puertas)
        {
            this.puertas = puertas;
        }
        #endregion
    }
}
