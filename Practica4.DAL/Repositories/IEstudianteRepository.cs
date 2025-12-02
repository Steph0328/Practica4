using System.Collections.Generic;


namespace Practica4.DAL.Repositories
{
    public interface IEstudianteRepository
    {
        List<Estudiante> GetAll();
        Estudiante GetById(int id);
    }
}
