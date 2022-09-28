using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPISevice.Models;

namespace WebAPISevice.Models
{
    public class VehiculoCLS
    {
        public int IdVehiculo { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Año { get; set; }
        public string Placa { get; set; }



        public int IdCliente { get; set; }
        //public string ClienteVehiculo { get; set; }
    }
}