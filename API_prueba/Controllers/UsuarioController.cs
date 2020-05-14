using API_prueba.Data;
using API_prueba.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_prueba.Controllers
{
    public class UsuarioController : ApiController
    {

        //GET:  api/Usuario
        public HttpResponseMessage Get()
        {
            HttpResponseMessage answer = null;
            UsrResponse response = new UsrResponse();

            try
            {
                using (DataSet data = UsrDataDb.UsrGetAll())
                {
                    if (data != null)
                    {
                        response.Code = 1;
                        response.Message = "Ok";

                        if (data.Tables[0].Rows.Count > 0)
                        {
                            Usuarios[] list = new Usuarios[data.Tables[0].Rows.Count];

                            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                            {
                                Usuarios obj = new Usuarios();

                                obj.id = Convert.ToInt32(data.Tables[0].Rows[i][0]);
                                obj.nombre = Convert.ToString(data.Tables[0].Rows[i][1]);
                                obj.Ap = Convert.ToString(data.Tables[0].Rows[i][2]);
                                obj.Am = Convert.ToString(data.Tables[0].Rows[i][3]);
                                obj.genero = Convert.ToInt32(data.Tables[0].Rows[i][4]);
                                obj.fecha_nacimiento = Convert.ToString(data.Tables[0].Rows[i][5]);
                                obj.direccion = Convert.ToString(data.Tables[0].Rows[i][6]);
                                obj.delegacion = Convert.ToInt32(data.Tables[0].Rows[i][7]);
                                obj.telefono = Convert.ToString(data.Tables[0].Rows[i][8]);
                                obj.email = Convert.ToString(data.Tables[0].Rows[i][9]);
                                obj.password = Convert.ToString(data.Tables[0].Rows[i][10]);

                                list[i] = obj;

                            }
                            response.Values = list;
                        }
                        answer = Request.CreateResponse(response);
                    }
                    else
                    {
                        response.Code = -1;
                        response.Message = "ups!! algo salió mal°°";
                        answer = Request.CreateResponse(response);
                    }
                }


            }
            catch (Exception ex)
            {
                response.Code = -1;
                response.Message = ex.ToString();
                answer = Request.CreateResponse(response);
            }
            return answer;
        }




        //GET: api/Usuario/1
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage answer = null;
            UsrResponse response = new UsrResponse();

            try
            {

                using (DataSet data = UsrDataDb.UsrGetOne(id))
                {
                    if (data != null)
                    {
                        response.Code = 1;
                        response.Message = "Ok";

                        if (data.Tables[0].Rows.Count > 0)
                        {
                            Usuarios[] list = new Usuarios[data.Tables[0].Rows.Count];
                            Usuarios obj = new Usuarios();

                            obj.id = Convert.ToInt32(data.Tables[0].Rows[0][0]);
                            obj.nombre = Convert.ToString(data.Tables[0].Rows[0][1]);
                            obj.Ap = Convert.ToString(data.Tables[0].Rows[0][2]);
                            obj.Am = Convert.ToString(data.Tables[0].Rows[0][3]);
                            obj.genero = Convert.ToInt32(data.Tables[0].Rows[0][4]);
                            obj.fecha_nacimiento = Convert.ToString(data.Tables[0].Rows[0][5]);
                            obj.direccion = Convert.ToString(data.Tables[0].Rows[0][6]);
                            obj.delegacion = Convert.ToInt32(data.Tables[0].Rows[0][7]);
                            obj.telefono = Convert.ToString(data.Tables[0].Rows[0][8]);
                            obj.email = Convert.ToString(data.Tables[0].Rows[0][9]);
                            obj.password = Convert.ToString(data.Tables[0].Rows[0][10]);

                            list[0] = obj;
                            response.Values = list;

                        }
                        answer = Request.CreateResponse(response);
                    }
                    else
                    {
                        response.Code = -1;
                        response.Message = "ups!! algo salió mal°°";
                        answer = Request.CreateResponse(response);
                    }
                }

            }
            catch (Exception ex)
            {
                response.Code = -1;
                response.Message = ex.ToString();
                answer = Request.CreateResponse(response);

            }
            return answer;
        }


        // POST: api/Usuarios
        public HttpResponseMessage Post([FromBody]Usuarios values)
        {
            HttpResponseMessage answer = null;
            UsrResponse response = new UsrResponse();

            try
            {
                int index = UsrDataDb.UsrAdd(values);

                if (index > 0)
                {
                    response.Code = 1;
                    response.Message = "Guardado";
                }
                else
                {
                    response.Code = 0;
                    response.Message = "No guardado";
                }
                answer = Request.CreateResponse(response);

            }
            catch (Exception ex)
            {
                response.Code = -1;
                response.Message = ex.ToString();
                answer = Request.CreateResponse(response);
            }
            return answer;
        }// fin metodo





        // PUT: api/Usuario/
        public HttpResponseMessage Put([FromBody]Usuarios values)
        {
            HttpResponseMessage answer = null;
            UsrResponse response = new UsrResponse();

            try
            {
                int rowCount = UsrDataDb.UsrUpdate(values);

                if (rowCount > 0)
                {
                    response.Code = 1;
                    response.Message = "Actualizado";
                }
                else
                {
                    response.Code = 0;
                    response.Message = "No Actualizado";

                }

                answer = Request.CreateResponse(response);


            }
            catch (Exception ex)
            {
                response.Code = -1;
                response.Message = ex.ToString();
                answer = Request.CreateResponse(response);
            }

            return answer;
        }






        // DELETE: api/GpsData/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage answer = null;
            UsrResponse response = new UsrResponse();

            try
            {
                int rowCount = UsrDataDb.UsrDelete(id);

                if (rowCount > 0)
                {
                    response.Code = 1;
                    response.Message = "Eliminado";
                }
                else
                {
                    response.Code = 0;
                    response.Message = "NO eliminado";

                }

                answer = Request.CreateResponse(response);


            }
            catch (Exception ex)
            {
                response.Code = -1;
                response.Message = ex.ToString();
                answer = Request.CreateResponse(response);
            }

            return answer;

        }




    }
}
