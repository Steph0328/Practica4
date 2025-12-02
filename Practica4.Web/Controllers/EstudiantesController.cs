using Practica4.BLL.Services;
using Practica4.DAL;
using System.Web.Mvc;

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

       

        // Create via MVC form (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudiante estudiante)
        {
            if (!ModelState.IsValid) return View(estudiante);

            _service.CrearEstudiante(estudiante);
            return RedirectToAction("Index");
        }

        // Update via MVC form (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Estudiante estudiante)
        {
            if (!ModelState.IsValid) return View(estudiante);

            _service.ActualizarEstudiante(estudiante);
            return RedirectToAction("Index");
        }

        // Delete via MVC form (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _service.EliminarEstudiante(id);
            return RedirectToAction("Index");
        }
    }
}
