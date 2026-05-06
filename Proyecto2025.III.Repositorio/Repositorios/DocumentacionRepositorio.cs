using Proyecto2025.III.BD.Datos;
using Proyecto2025.III.BD.Datos.Entity;
using Proyecto2025.III.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.III.Repositorio.Repositorios
{
    
        public class DocumentacionRepositorio : Repositorio<Documentacion>, IDocumentacionRepositorio
        {
            private readonly AppDBContext context;

            public DocumentacionRepositorio(AppDBContext context) : base(context)
            {
                this.context = context;
            }
        
    public async Task<List<DocumentacionListadoDTO>> SelectListaDocumentacion()
        {
            var lista = await context.Documentacions
                                    .Select(p => new DocumentacionListadoDTO
                                    {
                                        Id = p.Id,
                                        ArchivoUrl = p.ArchivoUrl ?? "",
                                        DatosDocumento = $"{p.FechaCreacion:dd/MM/yyyy} - {p.Descripcion}"
                                    })
                                    .ToListAsync();
            return lista;
        }
    }
}