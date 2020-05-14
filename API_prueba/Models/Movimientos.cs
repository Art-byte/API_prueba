using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_prueba.Models
{
    public class Movimientos
    {

        public int id { get; set; }
        public int cantidad { get; set; }
        public int tipo_movimiento {get;set;}
        public string descripcion { get; set; }
        public string fecha_movimiento { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public int id_usuario { get; set; }

    }
}