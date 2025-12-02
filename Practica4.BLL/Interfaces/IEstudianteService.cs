using Practica4.DAL;
using System.Collections.Generic;

namespace Practica4.BLL.Interfaces
{
    public interface IEstudianteService
    {
        List<Estudiante> ObtenerTodos();
        Estudiante ObtenerPorId(int id);
    }
}
