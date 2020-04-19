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
        public IRestResponse BuscarPorNombreApi(string nombre)
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
        public IRestResponse BuscarTodos()
        {
            var restClient = new RestClient("http://localhost:3000/");
            var request = new RestRequest(Method.GET);
            request.Resource = this.urlController;

            var response = restClient.Execute(request);
            return response;
        }
        public IRestResponse RegistarApi(usuario usuario)
        {
            var restClient = new RestClient("http://localhost:3000/");
            var request = new RestRequest(Method.POST);
            request.Resource = this.urlController + "/";
            request.RequestFormat = DataFormat.Json;
            var body = new
            {
                nombre = usuario.nombre,
                contrasena = usuario.contrasena,
                tipo = usuario.tipo
            };
            request.AddJsonBody(body);
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
                        usuario.id = usu.SelectToken("_id").ToString();
                        if (usu.SelectToken("nombre") == null)
                        {
                            usuario.status = "Indefinido";
                        }
                        else
                        {
                            usuario.nombre = usu.SelectToken("nombre").ToString();
                        }
                        if (usu.SelectToken("contrasena") == null)
                        {
                            usuario.status = "Indefinido";
                        }
                        else
                        {
                            usuario.contrasena = usu.SelectToken("contrasena").ToString();
                        }

                        if (usu.SelectToken("tipo") == null)
                        {
                            usuario.status = "Indefinido";
                        }
                        else
                        {
                            usuario.tipo = usu.SelectToken("tipo").ToString();
                        }
                        if (usu.SelectToken("date") == null)
                        {
                            usuario.status = "Indefinido";
                        }
                        else
                        {
                            usuario.status = usu.SelectToken("date").ToString();
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

        virtual public usuario Actualizar(string id, usuario usuario) 
        {
            usuario DatosActualizado = new usuario();
            DatosActualizado.nombre = usuario.nombre;
            DatosActualizado.contrasena = usuario.contrasena;
            DatosActualizado.tipo = usuario.tipo;
            var usu = TranformarUno(PeticionApiActualizar(id,DatosActualizado));
            return usu;
        }
        public IRestResponse PeticionApiActualizar(string id,usuario usuario)
        {
            var restClient = new RestClient("http://localhost:3000/");
            var request = new RestRequest(Method.PATCH);
            request.Resource = this.urlController + "/" + id;
            request.RequestFormat = DataFormat.Json;
            var body = new
            {
                nombre = usuario.nombre,
                contrasena = usuario.contrasena,
                tipo = usuario.tipo
            };
            request.AddJsonBody(body);
            var response = restClient.Execute(request);
            return response;
        }

        virtual public bool registrar(usuario usuario)
        {
            var res = RegistarApi(usuario);
            if (res.IsSuccessful)
            {
                return true;
            }
            return false;
        }

        public IRestResponse ElimiarUuarioApi(string id)
        {
            var restClient = new RestClient("http://localhost:3000/");
            var request = new RestRequest(Method.DELETE);
            request.Resource = this.urlController + "/" + id;
            var response = restClient.Execute(request);
            return response;
        }

        virtual public bool eliminar(string id)
        {
            if (id != null)
            {
                var res = ElimiarUuarioApi(id);
                if (res.IsSuccessful)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}