using Proyecto2025.III.BD.Datos;
using Proyecto2025.III.BD.Datos.Entity;
using Proyecto2025.III.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.III.Repositorio.Repositorios
{
    public interface ITipoDocumentacionRepositorio : IRepositorio<TipoDocumentacion>
    {
        Task<List<TipoDocumentacionListadoDTO>> SelectListaTipoDocumentacion();
    }
}
