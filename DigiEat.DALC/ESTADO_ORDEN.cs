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
    
    public partial class ESTADO_ORDEN
    {
        public ESTADO_ORDEN()
        {
            this.ORDEN = new HashSet<ORDEN>();
        }
    
        public decimal ID_ESTADO { get; set; }
        public string DESCRIPCION { get; set; }
    
        public virtual ICollection<ORDEN> ORDEN { get; set; }
    }
}
