using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASA_DE_EMPEÑOS.Models.Repository
{
    public class UsuarioBD
    {
        string urlController = "usuarios";
       virtual public IRestResponse BuscarPorNombreApi(string nombre)
        {
            var restClient = new RestClient("http://localhost:3000/");
            var request = new RestRequest(Method.GET);
            request.Resource = this.urlController + "/" + nombre;

            var response = restClient.Execute(request);
            return response;
        }

        virtual public usuario Tranformar (IRestResponse jsonRespuesta) 
        {
            usuario usuario = new usuario();
            if (jsonRespuesta.IsSuccessful)
            {
                if (jsonRespuesta.Content != null)
                {
                    JObject jObject = JObject.Parse(jsonRespuesta.Content);
                    string resul = jObject.ToString();
                    return JsonConvert.DeserializeObject<usuario>(resul);
                }
            }
            return usuario;
        }
    }
}