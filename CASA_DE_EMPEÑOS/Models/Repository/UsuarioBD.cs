using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections;
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

        virtual public usuario TranformarUno(IRestResponse jsonRespuesta) 
        {
            usuario usuario = new usuario();
            if (jsonRespuesta.IsSuccessful)
            {
                if (jsonRespuesta.Content != "null")
                {
                    JObject jObject = JObject.Parse(jsonRespuesta.Content);
                    string resul = jObject.ToString();
                    return JsonConvert.DeserializeObject<usuario>(resul);
                }
            }
            return usuario;
        }
        virtual public IRestResponse BuscarTodos() 
        {
            var restClient = new RestClient("http://localhost:3000/");
            var request = new RestRequest(Method.GET);
            request.Resource = this.urlController;

            var response = restClient.Execute(request);
            return response;
        }
        virtual public List<usuario> TranformarTodos(IRestResponse jsonRespuesta)
        {
            
            List<usuario> usuarios = new List<usuario>();
            if (jsonRespuesta.IsSuccessful)
            {

                if (jsonRespuesta.Content != "null")
                {
                    JArray jObject = JArray.Parse(jsonRespuesta.Content);
                    foreach (var usu in jObject)
                    {
                        usuario usuario = new usuario();
                        usuario.nombre = usu.SelectToken("nombre").ToString();
                        usuario.contrasena = usu.SelectToken("contrasena").ToString();
                        usuario.tipo = usu.SelectToken("tipo").ToString();
                        usuario.date = usu.SelectToken("date").ToString();
                        if (usu.SelectToken("status") == null)
                        {
                            usuario.status = "Indefinido";
                        }
                        else
                        {
                            usuario.status = usu.SelectToken("status").ToString();
                        }
                        if (usu.SelectToken("correo") == null)
                        {
                            usuario.correo = "Sin correo";
                        }
                        else
                        {
                            usuario.correo = usu.SelectToken("correo").ToString();
                        }
                       
                        usuarios.Add(usuario);
                    }
                    return usuarios;
                }
            }

            return usuarios;
        }
    }
}