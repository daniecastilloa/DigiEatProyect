using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digieat.Negocio
{
    public class Local
    {
        [Key]
        public decimal NUMERO_LOCAL { get; set; }
        public string CALLE { get; set; }
        public string COMUNA { get; set; }
        public string CIUDAD { get; set; }
        public string PAIS { get; set; }

    }
}
