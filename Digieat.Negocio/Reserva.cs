using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiEat.DALC;

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

		public decimal CANTIDAD_PERSONAS { get; set; }
		public virtual Cliente Cliente { get; set; } // Se supone que con esto le indico qué usuario dio de baja la reserva

		Entities db = new Entities();
		public bool CrearReserva()
		{
			try
			{
				db.CREATE_RESERVA(this.NUM_RESERVA, this.FECHA, this.HORA, this.CLIENTE_RUT,  this.CANTIDAD_PERSONAS);
				return true;
			}
			catch (Exception c)
			{
				return false;
			}

		}

	}
}
