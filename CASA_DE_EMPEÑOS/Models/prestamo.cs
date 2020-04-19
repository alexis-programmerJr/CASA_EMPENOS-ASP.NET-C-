using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASA_DE_EMPEÑOS.Models
{
    public class prestamo
    {
        public string id { get; set; }
        public string folio { get; set; }
        public string tipo { get; set; }
        public string estatus { get; set; }
        public string id_cliente { get; set; }
        public string descripcion { get; set; }
        public string date { get; set; }
    }
}