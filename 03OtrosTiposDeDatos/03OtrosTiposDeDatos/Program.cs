using System;
using System.Collections.Generic;

namespace _03OtrosTiposDeDatos
{
    public enum Meses
    {
        Enero, Febrero, Marzo = 5, Abril, Mayo, Junio, Julio, Agosto, Septiembre, Octubre, Noviembre, Diciembre
    };

    class Program
    {
        /// <summary>
        /// Metodo main
        /// </summary>
        /// <param name="args"> descripcion del parametro args </param>
        static void Main(string[] args)
        {
            #region nullable
            bool? miBool = null;
            int? miInt = null;
            #endregion

            #region enum
            Console.WriteLine("Mes actual " + Meses.Abril);
            #endregion

            #region anónimos
            var location = new { Pais = "Italia", Ciudad = "Milan" };
            Console.WriteLine("location - Pais: {0}, Ciudad: {1}", location.Pais, location.Ciudad);
            //location.Pais = "Francia";

            var locationB = new { Pais = "Francia", Ciudad = "París" };
            var cliente = new
            {
                Nombre = "Pepe",
                Apellido = "Lopez",
                Locacion = location
            };
            var clientes = new[]
            {
                new { Nombre = "Ana", Apellido = "Leis", Locacion = locationB },
                new { Nombre = "Julia", Apellido = "Vara", Locacion = location },
                new { Nombre = "Fer", Apellido = "Marquez", Locacion = locationB },
                cliente
            };
            foreach (var cl in clientes)
            {
                Console.WriteLine("cliente - Nombre {0}, Pais {1}", cl.Nombre, cl.Locacion.Pais);
            }
            #endregion

            #region tuplas
            var proveedor = (Nombre: "Ruben", Apellido: "Diaz");
            Console.WriteLine($"Provider: {proveedor.Nombre}, {proveedor.Apellido}");
            Console.WriteLine("Provider: {0}, {1}", proveedor.Nombre, proveedor.Apellido);

            (string Nombre, string Apellido) proveedorB = (Nombre: "Lucia", Apellido: "Rana");
            proveedorB.Nombre = "Maria";
            Console.WriteLine($"Provider: {proveedorB.Nombre}, {proveedorB.Apellido}");
            #endregion

            #region tipos genericos
            var lista = new List<string>();
            var str = new Concatenar<int>();
            str.Agregar(5);
            str.Agregar(9);
            Console.WriteLine("str {0}", str.resultado);

            var strBool = new Concatenar<bool>();
            strBool.Agregar(false);
            strBool.Agregar(true);
            Console.WriteLine("strBool {0}", strBool.resultado);

            Console.ReadKey();
            #endregion
        }
    }
}
