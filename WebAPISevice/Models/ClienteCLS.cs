using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISevice.Models
{
    public class ClienteCLS
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
    }
}