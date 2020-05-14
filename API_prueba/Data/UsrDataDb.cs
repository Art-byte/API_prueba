using API_prueba.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API_prueba.Data
{
    public class UsrDataDb
    {

        public static int UsrAdd(Usuarios values)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[10];
            parameters[0] = new SqlParameter("@nombre", values.nombre);
            parameters[1] = new SqlParameter("@ap", values.Ap);
            parameters[2] = new SqlParameter("@am", values.Am);
            parameters[3] = new SqlParameter("@genero", values.genero);
            parameters[4] = new SqlParameter("@fecha_nacimiento", values.fecha_nacimiento);
            parameters[5] = new SqlParameter("@direccion", values.direccion);
            parameters[6] = new SqlParameter("@delegacion", values.delegacion);
            parameters[7] = new SqlParameter("@telefono", values.telefono);
            parameters[8] = new SqlParameter("@email", values.email);
            parameters[9] = new SqlParameter("@password", values.password);

            answer = Data.DataBaseConnection.ExecuteQuery("USUARIO_A", parameters);
            return answer;
        }


        public static int UsrUpdate(Usuarios values)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[11];

            parameters[0] = new SqlParameter("@id", values.id);
            parameters[1] = new SqlParameter("@nombre", values.nombre);
            parameters[2] = new SqlParameter("@ap", values.Ap);
            parameters[3] = new SqlParameter("@am", values.Am);
            parameters[4] = new SqlParameter("@genero", values.genero);
            parameters[5] = new SqlParameter("@fecha_nacimiento", values.fecha_nacimiento);
            parameters[6] = new SqlParameter("@direccion", values.direccion);
            parameters[7] = new SqlParameter("@delegacion", values.delegacion);
            parameters[8] = new SqlParameter("@telefono", values.telefono);
            parameters[9] = new SqlParameter("@email", values.email);
            parameters[10] = new SqlParameter("@password", values.password);

            answer = Data.DataBaseConnection.ExecuteQuery("USUARIO_U", parameters);
            return answer;

        }


        // Ojo el delete debe considerar las referencias con sus otras llaves, por lo cual el procedimiento a ejecutar debera tener 
        // eliminacion por cascada 
        public static int UsrDelete(int id)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", id);

            answer = Data.DataBaseConnection.ExecuteQuery("USUARIO_D", parameters);
            return answer;
        }


        public static DataSet UsrGetAll()
        {
            DataSet answer = null;
            SqlParameter[] parameters = new SqlParameter[0];
            answer = Data.DataBaseConnection.ExecuteQueryDataSet("USUARIO_GA", parameters);

            return answer;
        }


        public static DataSet UsrGetOne(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", id);
            return Data.DataBaseConnection.ExecuteQueryDataSet("USUARIO_GO", parameters);
        }



    }
}