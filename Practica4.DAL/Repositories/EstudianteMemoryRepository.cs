using System.Collections.Generic;
using System.Linq;
using Practica4.DAL.Data;

namespace Practica4.DAL.Repositories
{
    public class EstudianteMemoryRepository : IEstudianteRepository
    {
        public List<Estudiante> GetAll()
        {
            return EstudianteData.Estudiantes;
        }

        public Estudiante GetById(int id)
        {
            return EstudianteData.Estudiantes.FirstOrDefault(e => e.Id == id);
        }
    }
}
