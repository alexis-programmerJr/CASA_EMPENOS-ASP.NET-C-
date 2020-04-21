using CASA_DE_EMPEÑOS.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASA_DE_EMPEÑOS.Models
{
    public class prestamo
    {
        public static string IdClientInProces;
        PrestamoBD prestamoBD = new PrestamoBD();
        public string id { get; set; }
        public string folio { get; set; }
        public string tipo { get; set; }
        public string estatus { get; set; }
        public string id_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public string descripcion { get; set; }
        public string date { get; set; }

        public List<prestamo> Cargarlista()
        {
            var litsPres = prestamoBD.BuscarTodos();
            return prestamoBD.TranformarTodos(litsPres);
        }
        public void Cancelar(string id,prestamo prestamo) 
        {
            prestamoBD.Actualizar(id,prestamo);
        }
        public bool Registrar(prestamo prestamo) 
        {
            return prestamoBD.registrar(prestamo);
        }
        public bool Eliminar(prestamo prestamo) 
        {
            return prestamoBD.eliminar(prestamo.id);
        }

    }
}