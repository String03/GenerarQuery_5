using GenerarQuery_5.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerarQuery_5.EE
{
    public class Genero
    {
        [ClavePrimariaAttribute]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_reg { get; set; }
    }
}
