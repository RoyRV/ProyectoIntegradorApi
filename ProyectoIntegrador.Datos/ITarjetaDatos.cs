using ProyectoIntegrador.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegrador.Datos
{
    public interface ITarjetaDatos
    {
         TarjetaInfo ObtenerInformacionTarjeta(int tipoTarjeta,
                               string numeroTarjeta,
                               string titularTarjeta,
                               string mesExpiracion,
                               string añoExpiracion,
                               string codigoSeguridad);
    }
}
