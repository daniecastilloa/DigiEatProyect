using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digieat.Negocio
{
    public class Reserva
    {
		[Key]
		public decimal NUM_RESERVA { get; set; }
		public DateTime FECHA { get; set; }
		public string HORA { get; set; }
		[ForeignKey("Cliente")]
		public decimal CLIENTE_RUT { get; set; }
		public virtual Cliente Cliente { get; set; } // Se supone que con esto le indico qué usuario dio de baja la reserva
	}
}
