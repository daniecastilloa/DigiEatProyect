using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiEat.DALC;

namespace Digieat.Negocio
{
    public class Empleado
    {
        
        public decimal rut_empleado { get; set; }
        public string nombre_empleado { get; set; }
        public string apellido_pat { get; set; }
        public string apellido_mat { get; set; }
        public Nullable<decimal> telefono { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public Nullable<System.DateTime> fecha_contrato { get; set; }
        public string turno { get; set; }
        //public decimal local_numero_local { get; set; }
        public decimal tipo_empleado_id_cargo { get; set; }

        public TipoEmpleado TipoEmpleado { get; set; }

        Entities db = new Entities();

        public List<Empleado> ReadAll()
        {
            return this.db.EMPLEADO.Select(c => new Empleado()
            {
                rut_empleado = c.RUT_EMPLEADO,
                nombre_empleado = c.NOMBRE_EMPLEADO,
                apellido_pat = c.APELLIDO_PAT,
                apellido_mat = c.APELLIDO_MAT,
                telefono = c.TELEFONO,
                correo = c.CORREO,
                contrasena = c.CONTRASENA,
                fecha_contrato = c.FECHA_CONTRATO,
                turno = c.TURNO,
                TipoEmpleado = new TipoEmpleado()
                {
                    id_cargo = c.TIPO_EMPLEADO.ID_CARGO,
                    nom_cargo = c.TIPO_EMPLEADO.NOM_CARGO

                }

            }).ToList();
        }
        public bool Autenticar()
        {
            return db.EMPLEADO
                 .Where(c => c.CORREO == this.correo && c.CONTRASENA == this.contrasena)
            .FirstOrDefault() != null;

        }

    }
}
