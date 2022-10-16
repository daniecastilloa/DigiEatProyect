using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiEat.DALC;

namespace Digieat.Negocio
{
    public class Cliente
    {
        [Key]
        public decimal rut { get; set; }

        
        public string nombre { get; set; }
        
        public string apellido_pat { get; set; }
        
        public string apellido_mat { get; set; }
        
        public decimal telefono { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        [ForeignKey("Estado_cuenta")]
        public int estado_cuenta { get; set; }
        [ForeignKey("Mesa")]
        public int mesa_num_mesa { get; set; }
        [ForeignKey("Reserva")]
        public int? reserva_num_reserva { get; set; }

        //public virtual MESA MESA { get; set; }
        //public virtual RESERVA RESERVA { get; set; }

        Entities db = new Entities();

        public List<Cliente> ReadAll()
        {
            return this.db.CLIENTE.Select(c => new Cliente() {
                rut = c.RUT,
                nombre = c.NOMBRE,
                apellido_mat = c.APELLIDO_MAT,
                apellido_pat = c.APELLIDO_PAT,
                telefono = (decimal)c.TELEFONO,
                correo = c.CORREO,
                contrasena = c.CONTRASENA,
                estado_cuenta = (int)c.ESTADO_CUENTA,
            }).ToList();
        }

        public bool Autenticar()
        {
            return db.CLIENTE
                 .Where(c => c.CORREO == this.correo && c.CONTRASENA == this.contrasena)
            .FirstOrDefault() != null;

        }
    }
}
