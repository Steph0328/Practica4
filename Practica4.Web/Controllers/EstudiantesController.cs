using System.Web.Mvc;
using Practica4.BLL.Services;

namespace Practica4.Web.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly EstudianteService _service = new EstudianteService();

        public ActionResult Index()
        {
            var lista = _service.ObtenerTodos();
            return View(lista);
        }

        public ActionResult Details(int id)
        {
            var estudiante = _service.ObtenerPorId(id);
            if (estudiante == null) return HttpNotFound();
            return View(estudiante);
        }
    }
}
