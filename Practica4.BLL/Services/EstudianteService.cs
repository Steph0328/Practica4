using Practica4.BLL.Interfaces;
using Practica4.DAL;
using Practica4.DAL.Repositories;
using System.Collections.Generic;

namespace Practica4.BLL.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _repo;

        public EstudianteService()
        {
            _repo = new EstudianteMemoryRepository(); // SIN API POR AHORA ✔
        }

        public List<Estudiante> ObtenerTodos()
        {
            return _repo.GetAll();
        }

        public Estudiante ObtenerPorId(int id)
        {
            if (id <= 0) return null;
            return _repo.GetById(id);
        }

        public void CrearEstudiante(Estudiante estudiante)
        {
            if (estudiante == null) return;
            _repo.Create(estudiante);
        }

        public void ActualizarEstudiante(Estudiante estudiante)
        {
            if (estudiante == null || estudiante.Id <= 0) return;
            _repo.Update(estudiante);
        }

        public void EliminarEstudiante(int id)
        {
            if (id <= 0) return;
            _repo.Delete(id);
        }


    }
}
