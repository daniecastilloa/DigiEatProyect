//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DigiEat.DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORDEN
    {
        public ORDEN()
        {
            this.CAJA_FACTURA = new HashSet<CAJA_FACTURA>();
            this.ORDEN_DETALLES = new HashSet<ORDEN_DETALLES>();
        }
    
        public decimal NUM_ORDEN { get; set; }
        public decimal MESA_NUM_MESA { get; set; }
        public Nullable<System.DateTime> FECHA_ORDEN { get; set; }
        public decimal ESTADO_ORDEN_ID_ESTADO { get; set; }
    
        public virtual ICollection<CAJA_FACTURA> CAJA_FACTURA { get; set; }
        public virtual ESTADO_ORDEN ESTADO_ORDEN { get; set; }
        public virtual MESA MESA { get; set; }
        public virtual ICollection<ORDEN_DETALLES> ORDEN_DETALLES { get; set; }
    }
}
