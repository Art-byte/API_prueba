using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using API_prueba.Models;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using API_prueba.Data;

namespace API_prueba.Controllers
{
    public class AlertasController : ApiController
    {

        //GET: api/Alertas
        public HttpResponseMessage Get()
        {
            HttpResponseMessage answer = null;
            AlertResponse response = new AlertResponse();

            try
            {
                using (DataSet data = AlertDataDb.alertGetAll())
                {

                    if(data != null)
                    {
                        response.Code = 1;
                        response.Message = "Ok";

                            if(data.Tables[0].Rows.Count > 0)
                        {
                            Alertas[] list = new Alertas[data.Tables[0].Rows.Count];
                            for(int i=0; i<data.Tables[0].Rows.Count; i++)
                            {
                                Alertas obj = new Alertas();

                                obj.id = Convert.ToInt32(data.Tables[0].Rows[i][0]);
                                obj.nombre_recordatorio = Convert.ToString(data.Tables[0].Rows[i][1]);
                                obj.hora_de_recordatorio = Convert.ToString(data.Tables[0].Rows[i][2]);
                                obj.monto = Convert.ToInt32(data.Tables[0].Rows[i][3]);
                                obj.repetir = Convert.ToInt32(data.Tables[0].Rows[i][4]);
                                obj.id_usuario = Convert.ToInt32(data.Tables[0].Rows[i][5]);

                                list[i] = obj;
                            }
                            response.Values = list;
                        }
                        answer = Request.CreateResponse(response);
                    }
                    else
                    {
                        response.Code = -1;
                        response.Message = "mmm algo ha salido mal";
                        answer = Request.CreateResponse(response);
                    }


                }
            }
            catch(Exception ex)
            {
                response.Code = -1;
                response.Message = ex.ToString();
                answer = Request.CreateResponse(response);
            }
            return answer;
        }



        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage answer = null;
            AlertResponse response = new AlertResponse();

            try
            {

                using(DataSet data = AlertDataDb.alertGetOne(id))
                {
                    if(data != null)
                    {
                        response.Code = 1;
                        response.Message = "Ok";

                        if(data.Tables[0].Rows.Count > 0)
                        {
                            Alertas[] list = new Alertas[data.Tables[0].Rows.Count];
                            Alertas obj = new Alertas();

                            obj.id = Convert.ToInt32(data.Tables[0].Rows[0][0]);
                            obj.nombre_recordatorio = Convert.ToString(data.Tables[0].Rows[0][1]);
                            obj.hora_de_recordatorio = Convert.ToString(data.Tables[0].Rows[0][2]);
                            obj.monto = Convert.ToInt32(data.Tables[0].Rows[0][3]);
                            obj.repetir = Convert.ToInt32(data.Tables[0].Rows[0][4]);
                            obj.id_usuario = Convert.ToInt32(data.Tables[0].Rows[0][5]);

                            list[0] = obj;
                            response.Values = list;
                        }
                        answer = Request.CreateResponse(response);
                    }
                    else
                    {
                        response.Code = -1;
                        response.Message = "hubo un error, sorry";
                        answer = Request.CreateResponse(response);

                    }
                }

            }
            catch(Exception ex)
            {
                response.Code = -1;
                response.Message = ex.ToString();
                answer = Request.CreateResponse(response);
            }
            return answer;
        }



        //POST: api/Alertas
        public HttpResponseMessage Post([FromBody]Alertas values)
        {
            HttpResponseMessage answer = null;
            AlertResponse response = new AlertResponse();
            try
            {
                int index = AlertDataDb.alertAdd(values);

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
        }


        //PUT: api/Alertas/
        public HttpResponseMessage Put([FromBody]Alertas values)
        {
            HttpResponseMessage answer = null;
            AlertResponse response = new AlertResponse();

            try
            {
                int rowCount = AlertDataDb.alertUpdate(values);

                if (rowCount > 0)
                {
                    response.Code = 1;
                    response.Message = "Actualizado";
                }
                else
                {
                    response.Code = 0;
                    response.Message = "No actualizado";
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

        //DELETE: api/Alertas/1
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage answer = null;
            AlertResponse response = new AlertResponse();

            try
            {
                int rowCount = AlertDataDb.alertDelete(id);

                if (rowCount > 0)
                {
                    response.Code = 1;
                    response.Message = "Eliminado";
                }
                else
                {
                    response.Code = 0;
                    response.Message = "Error al eliminar";
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
