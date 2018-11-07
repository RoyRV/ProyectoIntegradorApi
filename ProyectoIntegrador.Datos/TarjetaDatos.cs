using ProyectoIntegrador.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegrador.Datos
{
    public class TarjetaDatos : ITarjetaDatos
    {
        string cadenaConexion = "server=RROJAS\\SQLEXPRESS;database=bdProyeIntegrador;Integrated Security=true";
        SqlConnection conexion;

        public TarjetaDatos()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public TarjetaInfo ObtenerInformacionTarjeta(int tipoTarjeta,
                                string numeroTarjeta,
                                string titularTarjeta,
                                string mesExpiracion,
                                string añoExpiracion,
                                string codigoSeguridad)
        {
            TarjetaInfo tarjetaInfo = null;
            string query = "sp_GetTarjetaByInfo";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //declarar los parametros del procedure
            comando.Parameters.AddWithValue("@idTipoTarjeta", tipoTarjeta);
            comando.Parameters.AddWithValue("@numeroTarjeta", numeroTarjeta);
            comando.Parameters.AddWithValue("@nombreTarjeta", titularTarjeta);
            comando.Parameters.AddWithValue("@securityCodeTarjeta", codigoSeguridad);
            comando.Parameters.AddWithValue("@mesExpiracionTarjeta", mesExpiracion);
            comando.Parameters.AddWithValue("@añoExpiracionTarjeta", añoExpiracion );
            //abrir la conexion
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            //verificar que tenga filas
            if (reader.HasRows) {
                tarjetaInfo = new TarjetaInfo();
                //leer el registro
                while (reader.Read()) {
                    tarjetaInfo.titularTarjeta = reader["nombreTarjeta"].ToString();
                    tarjetaInfo.numeroTarjeta = reader["numeroTarjeta"].ToString();
                    tarjetaInfo.tarjetaHabilitada = bool.Parse(reader["tarjetaHabilitada"].ToString());
                    tarjetaInfo.creditoDisponible = double.Parse(reader["creditoDisponible"].ToString());
                }
            }

            //cerrar conexion
            conexion.Close();

            return tarjetaInfo;
        }

    }
}
