using System.Collections.Generic;
using System.Linq;
using Practica4.DAL.Data;

namespace Practica4.DAL.Repositories
{
    public class EstudianteMemoryRepository : IEstudianteRepository
    {
        public void Create(Estudiante estudiante)
        {
            if (estudiante.Id == 0)
            {
                int nextId = EstudianteData.Estudiantes.Any()
                    ? EstudianteData.Estudiantes.Max(e => e.Id) + 1
                    : 1;

                estudiante.Id = nextId;
            }

            EstudianteData.Estudiantes.Add(estudiante);
        }

        public void Delete(int id)
        {
            var estudiante = EstudianteData.Estudiantes.FirstOrDefault(e => e.Id == id);

            if (estudiante != null)
            {
                EstudianteData.Estudiantes.Remove(estudiante);
            }
        }

        public List<Estudiante> GetAll()
        {
            return EstudianteData.Estudiantes;
        }

        public Estudiante GetById(int id)
        {
            return EstudianteData.Estudiantes.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Estudiante estudiante)
        {
            var resultado = EstudianteData.Estudiantes
        .FirstOrDefault(e => e.Id == estudiante.Id);

            if (resultado != null)
            {
                resultado.Nombre = estudiante.Nombre;
                resultado.Apellido = estudiante.Apellido;
                resultado.Edad = estudiante.Edad;
                resultado.Correo = estudiante.Correo;
            }
        }
    }
}
