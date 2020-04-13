using CASA_DE_EMPEÑOS.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASA_DE_EMPEÑOS.Models
{
    public class usuario
    {
     public usuario() 
        {
           
        }
        UsuarioBD usuarioBD = new UsuarioBD();
        protected string id { get; set; }
        public string nombre { get; set; }
        public string  contrasena { get; set; }
        public string tipo { get; set; }
        public string registrado { get; set; }
        public static bool SessionStatus = false;
        public static bool EsAdmin;
        public static usuario datosUsuarioActivo;
         public void IniciarSesion(usuario usu) 
        {
            var respuestaApi = this.usuarioBD.BuscarPorNombreApi(usu.nombre);
            datosUsuarioActivo = this.usuarioBD.Tranformar(respuestaApi);
            if (ValidarCredenciales(datosUsuarioActivo.nombre, datosUsuarioActivo.contrasena,usu))
            {
                SessionStatus = true;
            }
            else
            {
                SessionStatus = false;
            }

        }
        bool ValidarCredenciales(string nombre, string contraseña,usuario usu)
        {
            if (nombre == usu.nombre)
            {
                if (contraseña == usu.contrasena)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}