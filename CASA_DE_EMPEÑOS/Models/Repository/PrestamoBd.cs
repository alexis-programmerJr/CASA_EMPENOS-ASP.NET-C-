using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASA_DE_EMPEÑOS.Models.Repository
{
    public class PrestamoBD
    {
        string urlController = "prestamos";
        UsuarioBD UsuarioBD_ = new UsuarioBD();

        public IRestResponse BuscarPorFolioApi(string folio)
        {
            var restClient = new RestClient("http://localhost:3000/");
            var request = new RestRequest(Method.GET);
            request.Resource = this.urlController + "/" + folio;

            var response = restClient.Execute(request);
            return response;
        }
        virtual public prestamo TranformarUno(IRestResponse jsonRespuesta)
        {
            prestamo prestamo = new prestamo();
            if (jsonRespuesta.IsSuccessful)
            {
                if (jsonRespuesta.Content != "null")
                {
                    JObject jObject = JObject.Parse(jsonRespuesta.Content);
                    string resul = jObject.ToString();
                    return JsonConvert.DeserializeObject<prestamo>(resul);
                }
            }
            return prestamo;
        }
        public IRestResponse BuscarTodos()
        {
            var restClient = new RestClient("http://localhost:3000/");
            var request = new RestRequest(Method.GET);
            request.Resource = this.urlController;

            var response = restClient.Execute(request);
            return response;
        }
        public IRestResponse RegistarApi(prestamo prestamo)
        {
            var restClient = new RestClient("http://localhost:3000/");
            var request = new RestRequest(Method.POST);
            request.Resource = this.urlController + "/";
            request.RequestFormat = DataFormat.Json;
            var body = new
            {
                folio = prestamo.folio,
                tipo = prestamo.tipo,
                id_cliente = prestamo.id_cliente,
                descripcion = prestamo.descripcion
            };
            request.AddJsonBody(body);
            var response = restClient.Execute(request);
            return response;
        }
        virtual public List<prestamo> TranformarTodos(IRestResponse jsonRespuesta)
        {

            List<prestamo> prestamos = new List<prestamo>();
            if (jsonRespuesta.IsSuccessful)
            {

                if (jsonRespuesta.Content != "null")
                {
                    JArray jObject = JArray.Parse(jsonRespuesta.Content);
                    foreach (var usu in jObject)
                    {
                        prestamo prestamo = new prestamo();
                        prestamo.id = usu.SelectToken("_id").ToString();
                        if (usu.SelectToken("estatus") == null)
                        {
                            prestamo.estatus = "Error sin estatus";
                        }
                        else
                        {
                            var status = usu.SelectToken("estatus").ToString();
                            if (status == "True")
                            {
                                prestamo.estatus = "Activo";
                            }
                            else
                            {
                                prestamo.estatus = "Cancelado";
                            }
                        }
                        if (usu.SelectToken("id_cliente") == null)
                        {
                            prestamo.nombre_cliente = "Error sin cliente asignado";
                        }
                        else
                        {
                            prestamo.nombre_cliente = UsuarioBD_.TranformarUno(UsuarioBD_.BuscarPorIdApi(usu.SelectToken("id_cliente").ToString())).nombre;
                        }

                        if (usu.SelectToken("descripcion") == null)
                        {
                            prestamo.descripcion = "Sin descripcion";
                        }
                        else
                        {
                            prestamo.descripcion = usu.SelectToken("descripcion").ToString();
                        }
                        if (usu.SelectToken("tipo") == null)
                        {
                            prestamo.tipo = "error sin tipo";
                        }
                        else
                        {
                            prestamo.tipo = usu.SelectToken("tipo").ToString();
                        }
                        if (usu.SelectToken("folio") == null)
                        {
                            prestamo.folio = "Error sin folio";
                        }
                        else
                        {
                            prestamo.folio = usu.SelectToken("folio").ToString();
                        }

                        prestamos.Add(prestamo);
                    }
                    return prestamos;
                }
            }

            return prestamos;
        }  
        public IRestResponse PeticionApiActualizar(string id, prestamo prestamo)
        {
            var restClient = new RestClient("http://localhost:3000/");
            var request = new RestRequest(Method.PATCH);
            request.Resource = this.urlController + "/" + id;
            request.RequestFormat = DataFormat.Json;
            var body = new
            {
                estatus = prestamo.estatus,
                descripcion = prestamo.descripcion
            };
            request.AddJsonBody(body);
            var response = restClient.Execute(request);
            return response;
        }
        virtual public prestamo Actualizar(string id, prestamo prestamo)
        {
            prestamo DatosActualizado = new prestamo();
            DatosActualizado.folio = prestamo.folio;
            DatosActualizado.id_cliente = prestamo.id_cliente;
            DatosActualizado.tipo = DatosActualizado.tipo;
            DatosActualizado.estatus = "Cancelado";
            DatosActualizado.descripcion = prestamo.descripcion;
            var pres = TranformarUno(PeticionApiActualizar(id, DatosActualizado));
            return pres;
        }
        virtual public bool registrar(prestamo prestamo)
        {
            var res = RegistarApi(prestamo);
            if (res.IsSuccessful)
            {
                return true;
            }
            return false;
        }
        public IRestResponse ElimiarApi(string id)
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
                var res = ElimiarApi(id);
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