using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using API_prueba.Models;
using System.Data;

namespace API_prueba.Data
{
    public class AlertDataDb
    {

        public static int alertAdd(Alertas values)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@nombre_recordatorio", values.nombre_recordatorio);
            parameters[1] = new SqlParameter("@hora_de_recordatorio", values.hora_de_recordatorio);
            parameters[2] = new SqlParameter("@monto", values.monto);
            parameters[3] = new SqlParameter("@repetir", values.repetir);
            parameters[4] = new SqlParameter("@id_usuario", values.id_usuario);

            answer = Data.DataBaseConnection.ExecuteQuery("ALERTAS_A", parameters);
            return answer;

        }


        public static int alertUpdate(Alertas values)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("@id",values.id);
            parameters[1] = new SqlParameter("@nombre_recordatorio", values.nombre_recordatorio);
            parameters[2] = new SqlParameter("@hora_de_recordatorio", values.hora_de_recordatorio);
            parameters[3] = new SqlParameter("@monto", values.monto);
            parameters[4] = new SqlParameter("@repetir", values.repetir);
            parameters[5] = new SqlParameter("@id_usuario", values.id_usuario);

            answer = Data.DataBaseConnection.ExecuteQuery("ALERTAS_U", parameters);
            return answer;
        }



        public static int alertDelete(int id)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", id);

            answer = Data.DataBaseConnection.ExecuteQuery("ALERTAS_D", parameters);
            return answer;
        }


        public static DataSet alertGetAll()
        {
            DataSet answer = null;
            SqlParameter[] parameters = new SqlParameter[0];
            answer = Data.DataBaseConnection.ExecuteQueryDataSet("ALERTAS_GA", parameters);
            return answer;
        }

        public static DataSet alertGetOne(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", id);
            return Data.DataBaseConnection.ExecuteQueryDataSet("ALERTAS_GO", parameters);
        }


    }
}