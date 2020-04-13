using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace CASA_DE_EMPEÑOS.Models
{
   public class conexion
    {
       IRestResponse PeticionDePrueba() 
        {
            var restClient = new RestSharp.RestClient("http://localhost:3000/");
            var request = new RestRequest(Method.GET);
            var urlController = "clientes";

            request.Resource = urlController;

            var response = restClient.Execute(request);
            return response;
        }

        public void Prueba() 
        {
           var respuesta = PeticionDePrueba().Content;
        }


    }
}