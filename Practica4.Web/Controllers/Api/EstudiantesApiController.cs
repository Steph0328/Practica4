using System.Net;
using System.Web.Http;
using Practica4.BLL.Services;
using Practica4.DAL;

namespace Practica4.Web.Controllers.Api
{
    [RoutePrefix("api/estudiantes")]
    public class EstudiantesApiController : ApiController
    {
        private readonly EstudianteService _service = new EstudianteService();

        // GET /api/estudiantes
        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            var lista = _service.ObtenerTodos();
            return Ok(lista);
        }

        // GET /api/estudiantes/{id}
        [HttpGet, Route("{id:int}", Name = "GetEstudianteById")]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("El id debe ser mayor que 0.");

            var estudiante = _service.ObtenerPorId(id);
            if (estudiante == null)
                return NotFound();

            return Ok(estudiante);
        }

        // POST /api/estudiantes
        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody] Estudiante estudiante)
        {
            if (estudiante == null)
                return BadRequest("El cuerpo de la solicitud es inválido o está vacío.");

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(estudiante.Nombre))
                return BadRequest("El campo 'Nombre' es obligatorio.");
            if (string.IsNullOrWhiteSpace(estudiante.Apellido))
                return BadRequest("El campo 'Apellido' es obligatorio.");
            if (estudiante.Edad <= 0)
                return BadRequest("El campo 'Edad' debe ser un número mayor que 0.");
            if (string.IsNullOrWhiteSpace(estudiante.Correo))
                return BadRequest("El campo 'Correo' es obligatorio.");

            // Crear estudiante
            _service.CrearEstudiante(estudiante);

            // Devuelve 201 Created con Location apuntando al GET por id
            return CreatedAtRoute("GetEstudianteById", new { id = estudiante.Id }, estudiante);
        }

        // PUT /api/estudiantes/{id}
        [HttpPut, Route("{id:int}")]
        public IHttpActionResult Put(int id, [FromBody] Estudiante estudiante)
        {
            if (id <= 0)
                return BadRequest("El id debe ser mayor que 0.");
            if (estudiante == null)
                return BadRequest("El cuerpo de la solicitud es inválido o está vacío.");

            var existente = _service.ObtenerPorId(id);
            if (existente == null)
                return NotFound();

            // Actualizar sólo los campos enviados (si vienen con valores válidos)
            if (!string.IsNullOrWhiteSpace(estudiante.Nombre))
                existente.Nombre = estudiante.Nombre;

            if (!string.IsNullOrWhiteSpace(estudiante.Apellido))
                existente.Apellido = estudiante.Apellido;

            if (estudiante.Edad > 0)
                existente.Edad = estudiante.Edad;

            if (!string.IsNullOrWhiteSpace(estudiante.Correo))
                existente.Correo = estudiante.Correo;

            // Guardar cambios
            _service.ActualizarEstudiante(existente);

            // Devolver el recurso actualizado
            return Ok(existente);
        }

        // DELETE /api/estudiantes/{id}
        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("El id debe ser mayor que 0.");

            var existente = _service.ObtenerPorId(id);
            if (existente == null)
                return NotFound();

            _service.EliminarEstudiante(id);

            // 204 No Content cuando la eliminación fue exitosa
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}