using API_prueba.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API_prueba.Data
{
    public class MovDataDb
    {

        public static int movAdd(Movimientos values)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@cantidad", values.cantidad);
            parameters[1] = new SqlParameter("@tipo_movimiento", values.tipo_movimiento);
            parameters[2] = new SqlParameter("@descripcion", values.descripcion);
            parameters[3] = new SqlParameter("@fecha_movimiento", values.fecha_movimiento);
            parameters[4] = new SqlParameter("@latitud", values.latitud);
            parameters[5] = new SqlParameter("@longitud", values.longitud);
            parameters[6] = new SqlParameter("@id_usuario", values.id_usuario);

            answer = Data.DataBaseConnection.ExecuteQuery("MOVIMIENTOS_A", parameters);
            return answer;

        }


        public static int movUpdate(Movimientos values)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[8];
            parameters[0] = new SqlParameter("@id", values.id);
            parameters[1] = new SqlParameter("@cantidad", values.cantidad);
            parameters[2] = new SqlParameter("@tipo_movimiento", values.tipo_movimiento);
            parameters[3] = new SqlParameter("@descripcion", values.descripcion);
            parameters[4] = new SqlParameter("@fecha_movimiento", values.fecha_movimiento);
            parameters[5] = new SqlParameter("@latitud", values.latitud);
            parameters[6] = new SqlParameter("@longitud", values.longitud);
            parameters[7] = new SqlParameter("@id_Usuario", values.id_usuario);

            answer = Data.DataBaseConnection.ExecuteQuery("MOVIMIENTOS_U", parameters);
            return answer;
        }


        public static int movDelete(int id)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", id);

            answer = Data.DataBaseConnection.ExecuteQuery("MOVIMIENTOS_D", parameters);
            return answer;
        }

        public static DataSet movGetAll()
        {
            DataSet answer = null;
            SqlParameter[] parameters = new SqlParameter[0];
            answer = Data.DataBaseConnection.ExecuteQueryDataSet("MOVIMIENTOS_GA", parameters);
            return answer;
        }

        public static DataSet movGetOne(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", id);
            return Data.DataBaseConnection.ExecuteQueryDataSet("MOVIMIENTOS_GO", parameters);
        }



    }
}