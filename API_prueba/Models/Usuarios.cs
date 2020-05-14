using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_prueba.Models
{
    public class Usuarios
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string Ap { get; set; }
        public string Am { get; set; }
        public int genero { get; set; }
        public string fecha_nacimiento { get; set; }
        public string direccion { get; set; }
        public int delegacion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}