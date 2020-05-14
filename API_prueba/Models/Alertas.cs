using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_prueba.Models
{
    public class Alertas
    {

        public int id { get; set; }
        public string nombre_recordatorio { get; set; }
        public string hora_de_recordatorio { get; set; }
        public int monto { get; set; }
        public int repetir { get; set; }
        public int id_usuario { get; set; }


    }
}