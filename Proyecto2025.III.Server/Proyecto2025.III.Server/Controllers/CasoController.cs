using Proyecto2025.III.BD.Datos;
using Proyecto2025.III.Repositorio.Repositorios;
using Proyecto2025.III.BD.Datos.Entity;
using Proyecto2025.III.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Proyecto2025.III.Shared.ENUM;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/caso")]
    public class CasoController : ControllerBase
    {
        private readonly ICasoRepositorio repositorio;

        public CasoController(ICasoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: api/caso
        [HttpGet]
        public async Task<ActionResult<List<Caso>>> GetFull()
        {
            var lista = await repositorio.Select();

            if (lista == null)
            {
                return NotFound("No se encontraron registros.");
            }


            return Ok(lista);
        }

        // GET: api/caso/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Caso>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);

            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}.");
            }

            return Ok(entidad);
        }

        // GET: api/caso/GetByNumeroExpediente/123
        [HttpGet("GetByNumeroExpediente/{NumeroExpediente}")]
        public async Task<ActionResult<Caso>> GetByNumeroExpediente(int NumeroExpediente)
        {
            var entidad = await repositorio.GetByNumeroExpediente(NumeroExpediente);

            if (entidad is null)
            {
                return NotFound($"No existe registro con el Numero Expediente: {NumeroExpediente}.");
            }

            return Ok(entidad);
        }

        // GET: api/caso/listacaso
        [HttpGet("lista")]
        public async Task<ActionResult<List<CasoListadoDTO>>> ListaCaso()
        {
            var lista = await repositorio.SelectListaCaso();

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

        // POST: api/caso
        [HttpPost]
        public async Task<ActionResult<int>> Post(CasoDTO DTO)
        {
            try
            {
                Caso entidad = new Caso
                {
                    NumeroExpediente = DTO.NumeroExpediente,
                    FechaInicio = DTO.FechaInicio,
                    Estado = DTO.Estado,
                    Descripcion = DTO.Descripcion,
                    Tipo = DTO.Tipo,
                    EstadoRegistro = ENUMEstadoRegistro.Activo
                };

                var id = await repositorio.Insert(entidad);

                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el registro: {e.Message}");
            }
        }

        // PUT: api/caso/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CasoDTO dto)
        {
            var entidad = new Caso
            {
                NumeroExpediente = dto.NumeroExpediente,
                FechaInicio = dto.FechaInicio,
                Estado = dto.Estado,
                Descripcion = dto.Descripcion,
                Tipo = dto.Tipo
            };

            var flag = await repositorio.Update(id, entidad);

            if (!flag)
            {
                return BadRequest("Datos no válidos o el registro no existe.");
            }

            return Ok();
        }

        // DELETE: api/caso/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var flag = await repositorio.Delete(id);

            if (!flag)
            {
                return NotFound($"No existe el registro con el id: {id} o ya fue eliminado.");
            }

            return Ok($"Registro con el id: {id} eliminado correctamente.");
        }
    }
}