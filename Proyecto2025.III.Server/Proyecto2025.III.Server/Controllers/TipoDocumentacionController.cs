using Proyecto2025.III.BD.Datos;
using Proyecto2025.III.Repositorio.Repositorios;
using Proyecto2025.III.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/tipo-documentacion")]
    public class TipoDocumentacionController : ControllerBase
    {
        private readonly ITipoDocumentacionRepositorio repositorio;

        public TipoDocumentacionController(ITipoDocumentacionRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDocumentacionListadoDTO>>> ListaTipoDocumentacion()
        {
            var lista = await repositorio.SelectListaTipoDocumentacion();
           if (lista == null)
            {
                return NotFound("No se encontro elementos de la lista, VERIFICAR.");
            }
            if (lista.Count == 0)
            {
                return NotFound("Lista sin registros.");
            }

            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TipoDocumentacion>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);

            if (entidad is null)
                return NotFound();

            return Ok(entidad);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] TipoDocumentacionDTO dto)
        {
            var entidad = new TipoDocumentacion
            {
                Nombre = dto.Nombre
            };

            var id = await repositorio.Insert(entidad);

            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoDocumentacion dto)
        {
            var flag = await repositorio.Update(id, dto);

            if (!flag)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var flag = await repositorio.Delete(id);

            if (!flag)
                return NotFound();

            return Ok();
        }
    }
}