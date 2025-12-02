using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica4.DAL
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
    }
}
