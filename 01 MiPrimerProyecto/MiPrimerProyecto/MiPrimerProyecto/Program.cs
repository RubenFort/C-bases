using System;

namespace MiPrimerProyecto
{
    class Program
    {
        /// <summary>
        /// Método principal
        /// </summary>
        /// <param name="args"> descripción del parámetro args </param>
        static void Main(string[] args)
        {
            #region Imprimir
            Console.WriteLine("Hola Mundo!"); //Imprime por pantalla
            #endregion
            int num = 10;
            string nombre = "Rubén";
            var apellido = "López";

            Console.WriteLine("Ingresa tú nombre: ");
            nombre = Console.ReadLine(); //Leer linea por pantalla
            Console.WriteLine("Tú nombre es: " + nombre);

            //Tipos de datos
            byte miByte = 3;
            int positivo = 500;
            int negativo = -800;
            float miFloat = 23.12f;
            double miDouble = 123.12;
            decimal miDecimal = 12.456m;
            bool miBool = true;
            string miString = "cadena de texto";
            char miChar = 'a';

            #region ReadK
            Console.ReadKey(); //Espera a que el usuario pulse una tecla
            #endregion
        }
    }
}
