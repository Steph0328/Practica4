using Microsoft.Ajax.Utilities;
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

        // Obtener todos
        public JsonResult GetAll()
        {
            return Json(_service.ObtenerTodos(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var estudiante = _service.ObtenerPorId(id);
            if (estudiante == null) return HttpNotFound();
            return View(estudiante);
        }

        // Crear
        [HttpPost]
        public JsonResult Create(Estudiante estudiante)
        {
            _service.CrearEstudiante(estudiante);
            return Json(new { success = true });
        }

        // Obtener por ID
        public JsonResult GetById(int id)
        {
            var est = _service.ObtenerPorId(id);
            return Json(est, JsonRequestBehavior.AllowGet);
        }

        // Actualizar
        [HttpPost]
        public JsonResult Update(Estudiante estudiante)
        {
            _service.ActualizarEstudiante(estudiante);
            return Json(new { success = true });
        }

        // Eliminar
        [HttpPost]
        public JsonResult Delete(int id)
        {
            _service.EliminarEstudiante(id);
            return Json(new { success = true });
        }
    }
}
