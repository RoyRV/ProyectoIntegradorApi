using ProyectoIntegrador.Modelos;
using ProyectoIntegrador.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoIntegradorAPI.Controllers
{
    public class TrabajadorController : ApiController
    {
        TrabajadorNegocios negocios = new TrabajadorNegocios();


        [HttpGet]
        public List<Trabajador> ListarTrabajadores() {
            var lista =  negocios.ListarTrabajadores();
            return lista;
        }

        [HttpGet]
        public Trabajador GetTrabajadorById(int id) {
            var lista = negocios.ListarTrabajadores();
            Trabajador trabajador = lista.FirstOrDefault(x => x.IdTrabajador == id);
            return trabajador;
        }

        [HttpPost]
        public string CrearTrabajador(Trabajador trabajador) {
            string mensaje = "";
            mensaje = negocios.CrearTrabajador(trabajador);
            return mensaje;
        }

        [HttpPost]
        public string ActualizarTrabajador(Trabajador trabajador) {
            string mensaje = "";
            mensaje = negocios.ActualizarTrabajador(trabajador);
            return mensaje;
        }
        //VERBOS de llamadas HTTP
        [HttpGet]
        public string EliminarTrabajador(int IdTrabajador) {
            string mensaje = "";
            mensaje = negocios.EliminarTrabajador(IdTrabajador);
            return mensaje;
        }
    }
}
