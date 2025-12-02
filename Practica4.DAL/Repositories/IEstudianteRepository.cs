using System.Collections.Generic;


namespace Practica4.DAL.Repositories
{
    public interface IEstudianteRepository
    {
        List<Estudiante> GetAll();
        Estudiante GetById(int id);

        void Create(Estudiante estudiante);
        void Update(Estudiante estudiante);
        void Delete(int id);
    }
}
