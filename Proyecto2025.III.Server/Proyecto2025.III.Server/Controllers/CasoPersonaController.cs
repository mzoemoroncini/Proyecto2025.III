using Proyecto2025.III.BD.Datos;
using Proyecto2025.III.Repositorio.Repositorios;
using Proyecto2025.III.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/caso-persona")]
    public class CasoPersonaController : ControllerBase
    {
        private readonly ICasoPersonaRepositorio repositorio;

        public CasoPersonaController(ICasoPersonaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: api/caso-persona
        [HttpGet]
        public async Task<ActionResult<List<CasoPersona>>> GetFull()
        {
            var lista = await repositorio.Select();

            if (lista == null)
            {
                return NotFound("No se encontraron registros.");
            }

            return Ok(lista);
        }

        // GET: api/caso-persona/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CasoPersona>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);

            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}.");
            }

            return Ok(entidad);
        }

        // POST: api/caso-persona
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CasoPersonaDTO dto)
        {
            try
            {
                var entidad = new CasoPersona
                {
                    PersonaId = dto.PersonaId,
                    CasoId = dto.CasoId,
                };

                var id = await repositorio.Insert(entidad);

                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.InnerException?.Message ?? e.Message}");
            }
        }

        // PUT: api/caso-persona/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CasoPersona dto)
        {
            var flag = await repositorio.Update(id, dto);

            if (!flag)
            {
                return BadRequest("Datos no válidos o el registro no existe.");
            }

            return Ok();
        }

        // DELETE: api/caso-persona/5
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