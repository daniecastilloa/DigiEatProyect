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
    
    public partial class INGREDIENTES
    {
        public INGREDIENTES()
        {
            this.RECETA_INGREDIENTE = new HashSet<RECETA_INGREDIENTE>();
        }
    
        public decimal ID_INGREDIENTE { get; set; }
        public Nullable<decimal> CANTIDAD { get; set; }
        public string PROVEEDOR_RUT_EMPRESA { get; set; }
    
        public virtual PROVEEDOR PROVEEDOR { get; set; }
        public virtual ICollection<RECETA_INGREDIENTE> RECETA_INGREDIENTE { get; set; }
    }
}
