using DigiEat.DALC;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digieat.Negocio
{
    public class Bebida_Bar
    {

        public decimal id_bebida { get; set; }
        public string nom_bebida { get; set; }
        public decimal valor { get; set; }
        public byte[] imagen { get; set; }
        public int cantidad_bb { get; set; }


        Entities db = new Entities();
        OracleConnection ora = new OracleConnection("DATA SOURCE=localhost:1521/xe ; PASSWORD=1234; USER ID=DIGIEATDB");
        public List<Bebida_Bar> ObtenerBebidas()
        {
            List<Bebida_Bar> data2 = new List<Bebida_Bar>();

            OracleCommand comando = new OracleCommand("LISTABEBIDAS", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("listabebidas", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;


            ora.Open();
            using (OracleDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    Bebida_Bar b = new Bebida_Bar();
                    b.id_bebida = reader.GetFieldValue<decimal>(0);
                    b.nom_bebida = reader.GetFieldValue<string>(1);
                    b.valor = reader.GetFieldValue<decimal>(2);
                    b.imagen = reader.GetFieldValue<byte[]>(3);

                    data2.Add(b);
                }

            }
            ora.Close();
            return data2;

        }
        public decimal DevolverPrecioOriginal()
        {
            decimal valor = 0;
            using (OracleCommand command = new OracleCommand("BUSCAR_VALOR_BEBIDA", ora))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("idplato", OracleDbType.Decimal).Value = this.id_bebida;
                command.Parameters.Add("precio", OracleDbType.Decimal);
                command.Parameters["precio"].Direction = ParameterDirection.Output;

                ora.Open();
                command.ExecuteNonQuery();
                valor = int.Parse(command.Parameters["precio"].Value.ToString());
                ora.Close();
            }
            return valor;
        }

    }
}
