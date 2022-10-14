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
        [Required, MinLength(3, ErrorMessage = "El nombre debe contener entre {3} y {50} caracteres"), MaxLength(50)]
        public string nombre { get; set; }
        [Required, MinLength(3, ErrorMessage = "El apellido paterno debe contener entre {3} y {50} caracteres"), MaxLength(50)]
        public string apellido_pat { get; set; }
        [Required, MinLength(3, ErrorMessage = "El apellido materno debe contener entre {3} y {50} caracteres"), MaxLength(50)]
        public string apellido_mat { get; set; }
        [Required, MinLength(9, ErrorMessage ="El teléfono debe contener entre {9} y {11} números"), MaxLength(11)]
        public decimal telefono { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public int cuenta_user { get; set; }
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
                cuenta_user = (int)c.CUENTA_USER,
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
