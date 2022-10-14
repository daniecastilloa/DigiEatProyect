using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digieat.Negocio
{
    public class Mesa
    {
        [Key]
        public decimal NUM_MESA { get; set; }
        public string ESTADO_MESA { get; set; }
        [ForeignKey("Local")]
        public decimal LOCAL_NUMERO_LOCAL { get; set; }
        public virtual Local Local { get; set; }
    }
}
