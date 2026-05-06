using Microsoft.AspNetCore.Mvc;
using Proyecto2025.III.BD.Datos;
using Proyecto2025.III.Repositorio.Repositorios;
using Proyecto2025.III.Shared.DTO;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/persona")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepositorio repositorio;

        public PersonaController(IPersonaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: api/persona
        [HttpGet]
        public async Task<ActionResult<List<Persona>>> GetFull()
        {
            var lista = await repositorio.Select();

            if (lista == null)
            {
                return NotFound("No se encontraron registros.");
            }

            return Ok(lista);
        }

        // GET: api/persona/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Persona>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);

            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}.");
            }

            return Ok(entidad);
        }

        // POST: api/persona
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] PersonaDTO dto)
        {
            var entidad = new Persona
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                DNI = dto.DNI,
                Mail = dto.Mail,
                TasaJusticia_Aportes = dto.TasaJusticia_Aportes
            };

            var id = await repositorio.Insert(entidad);

            return Ok(id);
        }

        // PUT: api/persona/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Persona dto)
        {
            var flag = await repositorio.Update(id, dto);

            if (!flag)
            {
                return BadRequest("Datos no válidos o el registro no existe.");
            }

            return Ok();
        }

        // DELETE: api/persona/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var flag = await repositorio.Delete(id);

            if (!flag)
            {
                return NotFound($"No existe el registro con el id: {id} o ya fue eliminado.");
            }

            return Ok();
        }
    }
}