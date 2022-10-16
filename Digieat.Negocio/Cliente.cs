using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiEat.DALC;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Digieat.Negocio
{
    public class Cliente
    {
        public decimal rut_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido_pat { get; set; }
        public string apellido_mat { get; set; }
        public decimal? telefono { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public decimal mesa_num_mesa { get; set; }
        public decimal num_estado { get; set; }
        public string nombre_estado { get; set; }

        //public virtual MESA MESA { get; set; }
        //public virtual RESERVA RESERVA { get; set; }

        Entities db = new Entities();

        //public List<Cliente> ReadAll()
        //{
        //    return this.db.CLIENTE.Select(c => new Cliente() {
        //        rut = c.RUT,
        //        nombre = c.NOMBRE,
        //        apellido_mat = c.APELLIDO_MAT,
        //        apellido_pat = c.APELLIDO_PAT,
        //        telefono = (decimal)c.TELEFONO,
        //        correo = c.CORREO,
        //        contrasena = c.CONTRASENA,
        //        estado_cuenta = (int)c.ESTADO_CUENTA,
        //    }).ToList();
        //}

        OracleConnection ora = new OracleConnection("DATA SOURCE=localhost:1521/xe ; PASSWORD=1234; USER ID=DIGIEATDB");
        public List<Cliente> ObtenerCliente()
        {
            List<Cliente> clientedatos = new List<Cliente>();

            OracleCommand comando = new OracleCommand("LISTACLIENTES", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("listamesas", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();

            ora.Open();
            using (OracleDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {

                    Cliente c = new Cliente();
                    c.rut_cliente = reader.GetFieldValue<decimal>(0);
                    c.nombre = reader.GetFieldValue<string>(1);
                    c.apellido_pat = reader.GetFieldValue<string>(2);
                    c.apellido_mat = reader.GetFieldValue<string>(3);
                    c.telefono = reader.GetFieldValue<decimal>(4);
                    c.correo = reader.GetFieldValue<string>(5);
                    c.contrasena = reader.GetFieldValue<string>(6);
                    c.mesa_num_mesa = reader.GetFieldValue<decimal>(7);
                    c.num_estado = reader.GetFieldValue<decimal>(8);
                    c.nombre_estado = reader.GetFieldValue<string>(9);
                    clientedatos.Add(c);

                }

            }
            ora.Close();
            return clientedatos;

        }






        public bool Autenticar()
        {
            return db.CLIENTE
                 .Where(c => c.CORREO == this.correo && c.CONTRASENA == this.contrasena)
            .FirstOrDefault() != null;

        }
    }
}
