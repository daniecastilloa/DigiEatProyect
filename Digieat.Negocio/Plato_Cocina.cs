using DigiEat.DALC;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digieat.Negocio
{
    public class Plato_Cocina
    {
        [Key]
        public decimal id_plato { get; set; }
        public string nom_plato { get; set; }
        public decimal valor { get; set; }
        public decimal num_categoria { get; set; }
        public string nom_categoria { get; set; }
        public byte[] imagen { get; set; }
        public int cantidad_pc { get; set; }


        Entities db = new Entities();
        OracleConnection ora = new OracleConnection("DATA SOURCE=localhost:1521/xe ; PASSWORD=1234; USER ID=DIGIEATDB");
        public List<Plato_Cocina> ObtenerPlatos()
        {
            List<Plato_Cocina> data = new List<Plato_Cocina>();

            OracleCommand comando = new OracleCommand("LISTAPLATOS", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("listaplatos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            ora.Open();
            using (OracleDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    Plato_Cocina plato = new Plato_Cocina();
                    plato.id_plato = reader.GetFieldValue<decimal>(0);
                    plato.nom_plato = reader.GetFieldValue<string>(1);
                    plato.valor = reader.GetFieldValue<decimal>(2);
                    plato.imagen = reader.GetFieldValue<byte[]>(3);

                    data.Add(plato);
                }

            }
            ora.Close();
            return data;

        }

        //    public List<Plato_Cocina> Buscar_Plato()
        //    {
        //        List<Plato_Cocina> plato = new List<Plato_Cocina>();
        //        using (OracleCommand command = new OracleCommand("BUSCAR_PLATO", ora))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.Add("idplato", OracleDbType.Varchar2).Value = this.id_plato;
        //            command.Parameters.Add("plato", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

        //            OracleDataAdapter adaptador = new OracleDataAdapter();
        //            adaptador.SelectCommand = command;


        //            ora.Open();
        //            using (OracleDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {

        //                    Plato_Cocina pc = new Plato_Cocina();
        //                    pc.id_plato = reader.GetFieldValue<decimal>(0);
        //                    pc.nom_plato = reader.GetFieldValue<string>(1);
        //                    pc.valor = reader.GetFieldValue<decimal>(2);
        //                    pc.imagen = reader.GetFieldValue<byte[]>(3);
        //                    pc.nom_categoria= reader.GetFieldValue<string>(4);
        //                    plato.Add(pc);

        //                }

        //            }
        //            ora.Close();
        //            return plato;

        //        }
        //    }

        //    public List<Plato_Cocina> Obtener_Categorias()
        //    {
        //        List<Plato_Cocina> categorias = new List<Plato_Cocina>();

        //        OracleCommand comando = new OracleCommand("LISTA_CATEGORIAS_PLATO", ora);
        //        comando.CommandType = System.Data.CommandType.StoredProcedure;
        //        comando.Parameters.Add("categorias", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

        //        OracleDataAdapter adaptador = new OracleDataAdapter();
        //        adaptador.SelectCommand = comando;

        //        ora.Open();
        //        using (OracleDataReader reader = comando.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                Plato_Cocina plato = new Plato_Cocina();
        //                plato.num_categoria = reader.GetFieldValue<decimal>(0);
        //                plato.nom_categoria = reader.GetFieldValue<string>(1);
        //                categorias.Add(plato);
        //            }

        //        }
        //        ora.Close();
        //        return categorias;

        //    }

        //    public bool AgregarPlato()
        //    {
        //        try
        //        {
        //            db.CREATE_PLATO_COCINA(this.id_plato, this.nom_plato, this.valor,this.imagen,this.num_categoria);
        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }

        //    }

        //    public decimal ObtenerID()
        //    {
        //        decimal id = 0;
        //        using (OracleCommand command = new OracleCommand("OBTENER_ID_PLATO", ora))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = this.nom_plato;
        //            command.Parameters.Add("idplato", OracleDbType.Decimal);
        //            command.Parameters["idplato"].Direction = ParameterDirection.Output;

        //            ora.Open();
        //            command.ExecuteNonQuery();
        //            id = int.Parse(command.Parameters["idplato"].Value.ToString());
        //            ora.Close();
        //        }
        //        return id;
        //    }
        //    public bool Modificar_Plato()
        //    {
        //        try
        //        {
        //            db.MODIFICAR_PLATO_COCINA(this.id_plato, this.nom_plato, this.valor, this.imagen, this.num_categoria);
        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    }
        //    public bool EliminarPlato()
        //    {
        //        try
        //        {
        //            db.DELETE_PLATO_COCINA(this.id_plato);
        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    }

        //    public decimal DevolverPrecioOriginal()
        //    {
        //        decimal valor = 0;
        //        using (OracleCommand command = new OracleCommand("BUSCAR_VALOR_PLATO", ora))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.Add("idplato", OracleDbType.Decimal).Value = this.id_plato;
        //            command.Parameters.Add("precio", OracleDbType.Decimal);
        //            command.Parameters["precio"].Direction = ParameterDirection.Output;

        //            ora.Open();
        //            command.ExecuteNonQuery();
        //            valor = int.Parse(command.Parameters["precio"].Value.ToString());
        //            ora.Close();
        //        }
        //        return valor;
        //    }
    }
}
