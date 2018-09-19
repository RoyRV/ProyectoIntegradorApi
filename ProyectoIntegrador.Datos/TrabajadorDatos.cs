using ProyectoIntegrador.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProyectoIntegrador.Datos
{
    public class TrabajadorDatos
    {
        string cadenaConexion = "server=RROJAS\\SQLEXPRESS;database=bdProyeIntegrador;Integrated Security=true";
        SqlConnection conexion;

        public TrabajadorDatos()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public List<Trabajador> ListarTrabajadores() {
            List<Trabajador> trabajadores = null;
            string sqlStatement = "sp_ListarTrabajadores";
            SqlCommand comando = new SqlCommand(sqlStatement, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //abrir la conexion
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            //verificar que tenga filas para leer
            if (reader.HasRows) {
                //inicializamos la lista de trabajadores
                trabajadores = new List<Trabajador>();
                //empezamos a leer el arreglo
                while (reader.Read()) {
                    Trabajador trabajador = new Trabajador();
                    trabajador.IdTrabajador = int.Parse(reader["IdTrabajador"].ToString());
                    trabajador.NombreTrabajador = reader["NombreTrabajador"].ToString();
                    trabajador.ApellidoTrabajador = reader["ApellidoTrabajador"].ToString();
                    trabajador.DniTrabajador = reader["DniTrabajador"].ToString();
                    //agregarlo a la lista
                    trabajadores.Add(trabajador);
                }
            }
            //cerrar la conexion
            conexion.Close();
            return trabajadores;
        }

        public void ActualizarTrabajador(Trabajador trabajador)
        {
            //abrir conexioon
            conexion.Open();
            //establecer el statement
            string sqlStatement = "sp_ActualizarTrabajador";
            //establecemos el comando
            SqlCommand comando = new SqlCommand(sqlStatement, conexion);
            //establecemos que es un procedure
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //la creacion de los parametros
            comando.Parameters.AddWithValue("@idtrabajador", trabajador.IdTrabajador);
            comando.Parameters.AddWithValue("@nombretrabajador", trabajador.NombreTrabajador);
            comando.Parameters.AddWithValue("@apellidotrabajador", trabajador.ApellidoTrabajador);
            comando.Parameters.AddWithValue("@dniTrabajador", trabajador.DniTrabajador);
            //ejecucion del procedure
            comando.ExecuteNonQuery();
            //cerrar conexion 
            conexion.Close();
        }

        public void EliminarTrabajador(int idTrabajador)
        {
            //abrir conexion
            conexion.Open();
            //establecer el statement
            string sqlStatement = "sp_EliminarTrabajador";
            //establecemos el comando
            SqlCommand comando = new SqlCommand(sqlStatement, conexion);
            //establecemos que es un procedure
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //la creacion de los parametros
            comando.Parameters.AddWithValue("@idtrabajador", idTrabajador);
            //ejecucion del procedure
            comando.ExecuteNonQuery();
            //cerrar conexion
            conexion.Close();
        }

        public void CrearTrabajador(Trabajador trabajador)
        {
            //abrir conexioon
            conexion.Open();
            //establecer el statement
            string sqlStatement = "sp_AgregarTrabajador";
            //establecemos el comando
            SqlCommand comando = new SqlCommand(sqlStatement, conexion);
            //establecemos que es un procedure
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //la creacion de los parametros
            comando.Parameters.AddWithValue("@nombretrabajador", trabajador.NombreTrabajador);
            comando.Parameters.AddWithValue("@apellidotrabajador", trabajador.ApellidoTrabajador);
            comando.Parameters.AddWithValue("@dniTrabajador", trabajador.DniTrabajador);
            //ejecucion del procedure
            comando.ExecuteNonQuery();
            //cerrar conexion 
            conexion.Close();
        }
    }
}
