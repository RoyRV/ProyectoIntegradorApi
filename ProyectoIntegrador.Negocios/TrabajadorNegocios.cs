using ProyectoIntegrador.Datos;
using ProyectoIntegrador.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegrador.Negocios
{
    public class TrabajadorNegocios
    {
        TrabajadorDatos datos = new TrabajadorDatos();

        public List<Trabajador> ListarTrabajadores()
        {
            return datos.ListarTrabajadores();
        }

        public string CrearTrabajador(Trabajador trabajador)
        {
            string mensaje = "";
            try
            {
                //agregar validaciones
                trabajador.Validar();
                datos.CrearTrabajador(trabajador);
                mensaje = "Trabajador creado!";
            }
            catch (Exception ex)
            {
                mensaje = "NO se creó el trabajador : " + ex.Message;
            }
            return mensaje;
        }


        public string ActualizarTrabajador(Trabajador trabajador)
        {
            string mensaje = "";
            try
            {
                if (trabajador.IdTrabajador == 0)
                {
                    mensaje = "Id Trabajador no es valido!";
                }
                //cuando existe un ID valido
                else
                {
                    //listar todos los trabadores y filtrar x el ID Trabajador
                    var existeTrabajador = datos.ListarTrabajadores().Any(x => x.IdTrabajador == trabajador.IdTrabajador);
                    if (existeTrabajador)
                    {
                        //agregar validaciones
                        trabajador.Validar();
                        datos.ActualizarTrabajador(trabajador);
                        mensaje = "Trabajador actualizado!";
                    }
                    else
                        mensaje = "Trabajador No existe";
                }
            }
            catch (Exception ex)
            {
                mensaje = "NO se creó el trabajador : " + ex.Message;
            }
            return mensaje;
        }

        public string EliminarTrabajador(int idTrabajador)
        {
            string mensaje = "";
            try
            {
                if (idTrabajador == 0)
                {
                    mensaje = "Id Trabajador no es valido!";
                }
                //cuando existe un ID valido
                else
                {
                    //listar todos los trabadores y filtrar x el ID Trabajador
                    var existeTrabajador = datos.ListarTrabajadores().Any(x => x.IdTrabajador == idTrabajador);
                    if (existeTrabajador)
                    {
                        datos.EliminarTrabajador(idTrabajador);
                        mensaje = "Trabajador eliminado!";
                    }
                    else
                        mensaje = "Trabajador No existe";
                }
            }
            catch (Exception ex)
            {
                mensaje = "NO se Elimino el trabajador : " + ex.Message;
            }

            return mensaje;
        }
    }
}
