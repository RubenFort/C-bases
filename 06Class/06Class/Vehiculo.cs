using System;
using System.Collections.Generic;
using System.Text;

namespace _06Class
{
    public enum ColorVehiculo
    {
        Ninguno, Blanco, Gris, Rojo, Azul, Negro
    }

    public enum Estatus
    {
        Existencia, Vendido, Entregado
    }

    public class Vehiculo
    {

        #region Atributos
        int id;
        int llantas;
        string modelo;
        int anio;
        ColorVehiculo color;
        Estatus estatus;
        #endregion

        #region Constructor
        public Vehiculo()
        {
            Id = 0;
            llantas = 4;
            modelo = "";
            anio = 2017;
            color = ColorVehiculo.Ninguno;
            estatus = Estatus.Existencia;
        }
        #endregion

        #region getters y setters (descriptores)
        public int Id { get; set; }
        public int Llantas { get; set; }
        public ColorVehiculo Color { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        #endregion

        #region Métodos
        public string Capturar()
        {
            //Capturar en BD
            return "Capturado";
        }
        
        public string vender()
        {
            //Registrar venta en BD
            return "Vendido";
        }
        #endregion
    }
}
