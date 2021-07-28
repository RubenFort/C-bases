using System;

namespace _05Excepcion
{
    class Program
    {   
        /// <summary>
        /// Menu Principal
        /// </summary>
        /// <param name="args"> Descripcion del argumento args </param>
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce un numero entero: ");
            try
            {
                int num = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                if (e.Message == null)
                {
                    throw;
                }
                else
                {
                    Console.WriteLine("Excepcion: " + e.Message);
                }
            }
            catch (FieldAccessException)
            {
                throw;
            }

            Console.ReadKey();
        }
    }
}
