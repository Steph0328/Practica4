using System.Collections.Generic;


namespace Practica4.DAL.Data
{
    public static class EstudianteData
    {
        public static List<Estudiante> Estudiantes = new List<Estudiante>()
        {
            new Estudiante { Id = 1, Nombre = "Ana",   Apellido = "Vargas",  Edad = 20, Correo = "ana@gmail.com" },
            new Estudiante { Id = 2, Nombre = "Luis",  Apellido = "Mora",    Edad = 22, Correo = "luis@gmail.com" },
            new Estudiante { Id = 3, Nombre = "Carla", Apellido = "Jiménez", Edad = 21, Correo = "carla@gmail.com" }
        };
    }
}
