using System;

namespace _04Operadores
{
    class Program
    {   
        /// <summary>
        /// Metodo Principal
        /// </summary>
        /// <param name="args"> Descripción del parametro args</param>
        static void Main(string[] args)
        {
            #region Operadores Matematicos
            Console.WriteLine("Probando mi primer proyecto");
            const int miConst = 10;
            Console.WriteLine("Ingresa un número entero:");
            try
            {
                int num = Int32.Parse(Console.ReadLine());
                int suma = miConst + num;
                Console.WriteLine("Suma: " + suma);

                int resta = miConst - num;
                Console.WriteLine("Resta: " + resta);

                int opuestoResta = -resta;
                Console.WriteLine("Opuesto resta: " + opuestoResta);

                int multiplicacion = miConst * num;
                Console.WriteLine("Multiplicacion: " + multiplicacion);
            }
            catch (Exception)
            {
                Console.WriteLine("Introduce un número entero");
            }
            #endregion

            #region Operadores de Asignacion
            Console.WriteLine("Ingresa un número entero:");
            try
            {
                int valor = 10;
                int numB = Int32.Parse(Console.ReadLine());
                valor += numB;
                Console.WriteLine("Resultado despues de += : " + valor);
                valor -= numB;
                Console.WriteLine("Resultado desdpues de -= : " + valor);
                valor *= numB;
                Console.WriteLine("Resultado desdpues de *= : " + valor);
                valor /= numB;
                Console.WriteLine("Resultado desdpues de /= : " + valor);
            }
            catch (Exception)
            {
                Console.WriteLine("Introduce un número entero");
            }
            #endregion

            #region Operadores Relacionales
            Console.WriteLine("Ingresa un número entero:");
            try
            {
                int numC = Int32.Parse(Console.ReadLine());
                if (numC == miConst)
                    Console.WriteLine("El numero introducido es igual a la constante");
                if (numC != miConst)
                    Console.WriteLine("El numero introducido no es igual a la constante");
                if (numC < miConst)
                    Console.WriteLine("El numero introducido es menor a la constante");
            }
            catch (Exception)
            {
                Console.WriteLine("Introduce un número entero");
            }
            #endregion

            #region Operadores Logicos
            
            try
            {
                Console.WriteLine("Ingresa un número entero X:");
                int numX = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa un número entero Y:");
                int numY = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa un número entero Z:");
                int numZ = Int32.Parse(Console.ReadLine());
                bool todosMayores = false;

                if (numX > 0 && numY > 0 && numZ > 0)
                {
                    Console.WriteLine("Todos los numeros son mayores que 0");
                    todosMayores = true;
                }
                if (numX > 0 || numY > 0 || numZ > 0)
                {
                    Console.WriteLine("Alguno de los numeros es mayor que 0");
                }
                if (!todosMayores)
                {
                    Console.WriteLine("No todos los numeros sonmayores que 0");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Introduce un número entero");
            }
            #endregion

            Console.ReadKey();
        }
    }
}
