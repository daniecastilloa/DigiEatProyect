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
    
    public partial class RESERVA
    {
        public RESERVA()
        {
            this.CLIENTE = new HashSet<CLIENTE>();
        }
    
        public decimal NUM_RESERVA { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string HORA { get; set; }
    
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }
    }
}
