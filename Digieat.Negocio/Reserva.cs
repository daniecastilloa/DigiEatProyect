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
	public class Reserva
	{
		[Key]
		public decimal NUM_RESERVA { get; set; }
		[DisplayName("Seleccione la Fecha")]
		public DateTime FECHA { get; set; }

		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH: mm}")]
		[DisplayName("Seleccione la Hora")]
		public string HORA { get; set; }
		[ForeignKey("Cliente")]

		[DisplayName("Rut del Cliente")]
		public decimal CLIENTE_RUT { get; set; }


        [DisplayName("Ingrese la cantidad de personas")]
        public decimal CANTIDAD_PERSONAS { get; set; }
		public virtual Cliente Cliente { get; set; } // Se supone que con esto le indico qué usuario dio de baja la reserva

		Entities db = new Entities();


        //Metodo para obtener una lista de los datos del cliente a partir del proceso almacenado que tenemos en la bd

        OracleConnection ora = new OracleConnection("DATA SOURCE=localhost:1521/xe ; PASSWORD=1234; USER ID=DIGIEATDB");
        //public List<Reserva> ObtenerReservas()
        //{
        //    List<Reserva> reservalista = new List<Reserva>();

        //    OracleCommand comando = new OracleCommand("LISTARESERVAS", ora);
        //    comando.CommandType = System.Data.CommandType.StoredProcedure;
        //    comando.Parameters.Add("listareservas", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

        //    OracleDataAdapter adaptador = new OracleDataAdapter();
        //    adaptador.SelectCommand = comando;


        //    ora.Open();
        //    using (OracleDataReader reader = comando.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {

        //            Reserva re = new Reserva();
        //            re.NUM_RESERVA = reader.GetFieldValue<decimal>(0);
        //            re.FECHA = reader.GetFieldValue<DateTime>(1);
        //            re.HORA = reader.GetFieldValue<string>(2);
        //            re.CLIENTE_RUT = reader.GetFieldValue<decimal>(3);
        //            re.CANTIDAD_PERSONAS = reader.GetFieldValue<decimal>(4);

        //            reservalista.Add(re);

        //        }

        //    }
        //    ora.Close();
        //    return reservalista;

        //}


        public bool AgregarReserva()
		{
            Random randomnumber = new Random();
            this.NUM_RESERVA = randomnumber.Next(100000, 999999);

            try
			{
				db.CREATE_RESERVA(this.NUM_RESERVA, this.FECHA, this.HORA, this.CLIENTE_RUT, this.CANTIDAD_PERSONAS);
				return true;
			}
			catch (Exception e)
			{
				return false;
			}

		}

	}
}
