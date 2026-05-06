using Proyecto2025.III.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.III.BD.Datos
{
    public class Documentacion : BaseEntity
    {

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [MaxLength(10000, ErrorMessage = "1 caracter mínimo")]
        public required string Descripcion { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [MaxLength(10000)]
        public string? ArchivoUrl { get; set; }



        // claves foraneas
        public int CasoId { get; set; }
        public Caso? Casos { get; set; }
        public int TipoDocumentacionId { get; set; }
        public TipoDocumentacion? TiposDocumentos { get; set; }
    }
}
