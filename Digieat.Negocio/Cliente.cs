﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiEat.DALC;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Digieat.Negocio;
using System.ComponentModel;


namespace Digieat.Negocio
{
    public class Cliente
    {
        public decimal rut_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido_pat { get; set; }
        public string apellido_mat { get; set; }
        public decimal? telefono { get; set; }
        [DisplayName("  Ingrese el Correo")]
        public string correo { get; set; }
        [DisplayName("  Ingrese la Contraseña")]
        public string contrasena { get; set; }


        [ForeignKey("Estado_cuenta")]
        public decimal estado_cuenta { get; set; }

        [ForeignKey("Mesa")]
        public int mesa_num_mesa { get; set; }

        [ForeignKey("Reserva")]
        public int? reserva_num_reserva { get; set; }


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

        //public List<Cliente> ObtenerCliente()
        //{

        //    return this.db.CLIENTE.Select(c => new Cliente() {
        //        rut_cliente = c.RUT,
        //        nombre = c.NOMBRE,
        //        apellido_mat = c.APELLIDO_MAT,
        //        apellido_pat = c.APELLIDO_PAT,
        //        telefono = (decimal)c.TELEFONO,
        //        correo = c.CORREO,
        //        contrasena = c.CONTRASENA,

        //        estado_cuenta = (int)c.ESTADO_CUENTA,

        //    }).ToList();
        //}

        public List<Cliente> ReadAll()
        {
            return this.db.CLIENTE.Select(c => new Cliente()
            {
                rut_cliente = c.RUT,
                nombre = c.NOMBRE,
                apellido_pat = c.APELLIDO_PAT,
                apellido_mat = c.APELLIDO_MAT,
                telefono = (decimal)c.TELEFONO,
                correo = c.CORREO,
                contrasena = c.CONTRASENA,
                estado_cuenta = (int)c.ESTADO_CUENTA,


            }).ToList();
        }

        public List<Cliente> ObtenerCliente()
        {
            List<Cliente> clientedatos = new List<Cliente>();

            OracleCommand comando = new OracleCommand("LISTACLIENTES", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("listamesas", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

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
                    //c.mesa_num_mesa = reader.GetFieldValue<decimal>(7);
                    c.estado_cuenta = reader.GetFieldValue<decimal>(8);
                    //c.nombre_estado = reader.GetFieldValue<string>(9);
                    clientedatos.Add(c);
                }
            }
            ora.Close();
            return clientedatos;

        }

        public string ObtenerNombre()
        {

            string nombrecliente;
            using (OracleCommand command = new OracleCommand("BUSCAR_NOMBRE_CL", ora))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("varcorreo", OracleDbType.Varchar2).Value = "carla.benitez@gmail.com";
                command.Parameters.Add("nnombre", OracleDbType.Varchar2, 30);
                command.Parameters["nnombre"].Direction = ParameterDirection.Output;
                ora.Open();

                command.ExecuteNonQuery();
                nombrecliente = command.Parameters["nnombre"].Value.ToString();
                ora.Close();
            }
            return nombrecliente;
        }

        public bool Autenticar()
        {
            return db.CLIENTE
                 .Where(c => c.CORREO == this.correo && c.CONTRASENA == this.contrasena)
            .FirstOrDefault() != null;

        }

        public bool AgregarCliente()
        {
            try
            {
                db.CREATE_CLIENTE(this.rut_cliente, this.nombre, this.apellido_pat, this.apellido_mat, this.telefono, this.correo, this.contrasena, 2,
                    1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
