using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISevice.Models
{
    public class FacturaCLS
    {
            public int IdFactura { get; set; }
            public string Numero_Factura { get; set; }
            public string IVA { get; set; }

            public int IdCliente { get; set; }
            public int IdMecanico { get; set; }
            public int IdRepuesto { get; set; }
    }
}