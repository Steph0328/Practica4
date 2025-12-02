using Microsoft.AspNetCore.Mvc;

namespace Practica4.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var lista = new[]
            {
                new { Id = 1, Nombre = "Carlos", Apellido = "Ramírez" },
                new { Id = 2, Nombre = "Ana", Apellido = "López" },
                new { Id = 3, Nombre = "María", Apellido = "González" }
            };

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id == 1)
                return Ok(new { Id = 1, Nombre = "Carlos", Apellido = "Ramírez" });

            if (id == 2)
                return Ok(new { Id = 2, Nombre = "Ana", Apellido = "López" });

            if (id == 3)
                return Ok(new { Id = 3, Nombre = "María", Apellido = "González" });

            return NotFound(new { Mensaje = "Estudiante no encontrado" });
        }
    }
}