using Proyecto2025.III.BD.Datos;
using Proyecto2025.III.Repositorio.Repositorios;
using Proyecto2025.III.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/documentacion")]
    public class DocumentacionController : ControllerBase
    {
        private readonly IDocumentacionRepositorio repositorio;

        public DocumentacionController(IDocumentacionRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: api/documentacion
        [HttpGet]
        public async Task<ActionResult<List<DocumentacionDTO>>> GetFull()
        {
            var lista = await repositorio.Select();

            if (lista == null)
            {
                return NotFound("No se encontraron registros.");
            }

            return Ok(lista);
        }

        // GET: api/documentacion/lista
        [HttpGet("lista")]
        public async Task<ActionResult<List<DocumentacionListadoDTO>>> ListaDocumentacion()
        {
            var lista = await repositorio.SelectListaDocumentacion();

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

        // GET: api/documentacion/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Documentacion>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);

            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}.");
            }

            return Ok(entidad);
        }

        // POST: api/documentacion
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] DocumentacionDTO dto)
        {
            try
            {
                var entidad = new Documentacion
                {
                    CasoId = dto.CasoId,
                    TipoDocumentacionId = dto.TipoDocumentacionId,
                    Descripcion = dto.Descripcion,
                    FechaCreacion = DateTime.Now,
                    ArchivoUrl = dto.ArchivoUrl
                };

                var id = await repositorio.Insert(entidad);

                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el registro: {e.Message}");
            }
        }

        // PUT: api/documentacion/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Documentacion dto)
        {
            var flag = await repositorio.Update(id, dto);

            if (!flag)
            {
                return BadRequest("Datos no válidos o el registro no existe.");
            }

            return Ok();
        }

        // DELETE: api/documentacion/5
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