using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASA_DE_EMPEÑOS.Models
{
    public class Clientes
    {
        public string nombre { get; set; }
        public string tipo { get; set; }
        public int numero_telefono { get; set; }
        public string direccion { get; set; }
        public string descripcion { get; set; }
        public string date { get; set; }
    }
}