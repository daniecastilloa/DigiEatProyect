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
    
    public partial class CLIENTE
    {
        public decimal RUT { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PAT { get; set; }
        public string APELLIDO_MAT { get; set; }
        public string TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string CONTRASEÑA { get; set; }
        public byte[] CUENTA_USER { get; set; }
        public decimal MESA_NUM_MESA { get; set; }
        public decimal RESERVA_NUM_RESERVA { get; set; }
    
        public virtual MESA MESA { get; set; }
        public virtual RESERVA RESERVA { get; set; }
    }
}
