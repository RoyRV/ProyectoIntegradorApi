using ProyectoIntegrador.Negocios;
using ProyectoIntegradorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoIntegradorAPI.Controllers
{
    public class PagoController : ApiController
    {
        ValidarPagoNegocios negocios = new ValidarPagoNegocios();
        [HttpPost]
        public ValidarPagoResponse ValidarPago(ValidarPagoRequest request) {
            ValidarPagoResponse response = new ValidarPagoResponse();
            string mensaje = "";
            response.TransaccionCompleta 
                =  negocios.ValidarPago(out mensaje,
                                        request.TipoTarjeta,request.NumeroTarjeta,
                                        request.TitularTarjeta, request.MontoConsumir,
                                        request.MesExpiracionTarjeta,request.AñoExpiracionTarjeta,
                                        request.CodigoSeguridadTarjeta);
            response.TransaccionMensaje = mensaje;

            return response;
        }
    }
}
