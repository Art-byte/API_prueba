using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_prueba.Models
{
    public class UsrResponse
    {

        public int Code { get; set; }
        public string Message { get; set; }
        public Usuarios[] Values { get; set; }
    }
}