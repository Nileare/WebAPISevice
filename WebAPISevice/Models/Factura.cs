//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPISevice.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Factura
    {
        public int IDFACTURA { get; set; }
        public string NUMERO_FACTURA { get; set; }
        public string IVA { get; set; }
        public int IDCLIENTE { get; set; }
        public int IDMECANICO { get; set; }
        public int IDREPUESTO { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Mecanico Mecanico { get; set; }
        public virtual Repuesto Repuesto { get; set; }
    }
}
