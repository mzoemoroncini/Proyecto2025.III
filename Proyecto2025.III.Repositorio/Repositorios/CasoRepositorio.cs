using Proyecto2025.III.BD.Datos;
using Proyecto2025.III.BD.Datos.Entity;
using Proyecto2025.III.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Proyecto2025.III.Repositorio.Repositorios
{
    public class CasoRepositorio : Repositorio<Caso>, ICasoRepositorio
    {
        private readonly AppDBContext context;

        public CasoRepositorio(AppDBContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<CasoListadoDTO>> SelectListaCaso()
        {
            var lista = await context.Casos
                                    .Select(p => new CasoListadoDTO
                                    {
                                        NumeroExpediente = p.NumeroExpediente,
                                        DatosCaso = $"{p.Estado} - {p.Tipo} - {p.NumeroExpediente}"
                                    })
                                    .ToListAsync();
            return lista;
        }
        public async Task<Caso?> GetByNumeroExpediente(int NumeroExpediente)
        {
            try
            {
                Caso? entidad = await context.Casos
                                             .FirstOrDefaultAsync(x => x.NumeroExpediente == NumeroExpediente);
                return entidad;
            }
            catch (Exception e)
            {
                throw;
            }



        }
    }
}

