using System;

namespace ProyectoIntegrador.Modelos
{
    public class Trabajador
    {
        public int IdTrabajador { get; set; }
        public string NombreTrabajador { get; set; }
        public string ApellidoTrabajador { get; set; }
        public string DniTrabajador { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(NombreTrabajador))
                throw new Exception("Nombre del Trabajador es requerido");
            else if (string.IsNullOrEmpty(ApellidoTrabajador))
                throw new Exception("Apellido del Trabajador es requerido");
            else if (string.IsNullOrEmpty(DniTrabajador))
                throw new Exception("Dni del Trabajador es requerido");
            else if (DniTrabajador.Length != 8)
                throw new Exception("DNI del trabajador tiene que tener 8 caracteres");
        }
    }
}
