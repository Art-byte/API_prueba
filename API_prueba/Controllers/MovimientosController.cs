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
    public class MovimientosController : ApiController
    {

        //GET api/Movimientos
        public HttpResponseMessage Get()
        {
            HttpResponseMessage answer = null;
            MovResponse response = new MovResponse();

            try
            {

                using (DataSet data = MovDataDb.movGetAll())
                {
                    if(data != null)
                    {
                        response.Code = 1;
                        response.Message = "Ok";

                        if(data.Tables[0].Rows.Count > 0)
                        {
                            Movimientos[] list = new Movimientos[data.Tables[0].Rows.Count];
                            for(int i=0; i<data.Tables[0].Rows.Count; i++)
                            {

                                Movimientos obj = new Movimientos();

                                obj.id = Convert.ToInt32(data.Tables[0].Rows[i][0]);
                                obj.cantidad = Convert.ToInt32(data.Tables[0].Rows[i][1]);
                                obj.tipo_movimiento = Convert.ToInt32(data.Tables[0].Rows[i][2]);
                                obj.descripcion = Convert.ToString(data.Tables[0].Rows[i][3]);
                                obj.fecha_movimiento = Convert.ToString(data.Tables[0].Rows[i][4]);
                                obj.latitud = Convert.ToDouble(data.Tables[0].Rows[i][5]);
                                obj.longitud = Convert.ToDouble(data.Tables[0].Rows[i][6]);
                                obj.id_usuario = Convert.ToInt32(data.Tables[0].Rows[i][7]);

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
            catch (Exception ex)
            {
                response.Code = -1;
                response.Message = ex.ToString();
                answer = Request.CreateResponse(response);
            }
            return answer;

        }

        //GET api/Movimientos/2
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage answer = null;
            MovResponse response = new MovResponse();

            try
            {
                using (DataSet data = MovDataDb.movGetOne(id))
                {
                    if(data != null)
                    {
                        response.Code = 1;
                        response.Message = "Ok";

                        if (data.Tables[0].Rows.Count > 0)
                        {
                            Movimientos[] list = new Movimientos[data.Tables[0].Rows.Count];
                            Movimientos obj = new Movimientos();

                            obj.id = Convert.ToInt32(data.Tables[0].Rows[0][0]);
                            obj.cantidad = Convert.ToInt32(data.Tables[0].Rows[0][1]);
                            obj.tipo_movimiento = Convert.ToInt32(data.Tables[0].Rows[0][2]);
                            obj.descripcion = Convert.ToString(data.Tables[0].Rows[0][3]);
                            obj.fecha_movimiento = Convert.ToString(data.Tables[0].Rows[0][4]);
                            obj.latitud = Convert.ToDouble(data.Tables[0].Rows[0][5]);
                            obj.longitud = Convert.ToDouble(data.Tables[0].Rows[0][6]);
                            obj.id_usuario = Convert.ToInt32(data.Tables[0].Rows[0][7]);

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



        //POST: api/Movimientos
        public HttpResponseMessage Post([FromBody]Movimientos values)
        {
            HttpResponseMessage answer = null;
            MovResponse response = new MovResponse();
            try
            {
                int index = MovDataDb.movAdd(values);

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
            catch(Exception ex)
            {
                response.Code = -1;
                response.Message = ex.ToString();
                answer = Request.CreateResponse(response);
            }
            return answer;
        }


        //PUT: api/Movimientos/
        public HttpResponseMessage Put([FromBody]Movimientos values)
        {
            HttpResponseMessage answer = null;
            MovResponse response = new MovResponse();

            try
            {
                int rowCount = MovDataDb.movUpdate(values);

                if(rowCount > 0)
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
            catch(Exception ex)
            {
                response.Code = -1;
                response.Message = ex.ToString();
                answer = Request.CreateResponse(response);
            }
            return answer;
        }



        //DELETE: api/Movimientos/1
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage answer = null;
            MovResponse response = new MovResponse();

            try
            {
                int rowCount = MovDataDb.movDelete(id);

                if(rowCount > 0)
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
            catch(Exception ex)
            {
                response.Code = -1;
                response.Message = ex.ToString();
                answer = Request.CreateResponse(response);
            }


            return answer;
        }




    }
}
