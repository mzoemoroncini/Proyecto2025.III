using Proyecto2025.III.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.III.Shared.DTO
{
    public class DocumentacionDTO : BaseEntityDTO
    {
        public int CasoId { get; set; }
        public int TipoDocumentacionId { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [MinLength(1, ErrorMessage = "Debe tener al menos 1 caracter")]
        [MaxLength(10000)]
        public string Descripcion { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [MaxLength(10000000)]
        public string? ArchivoUrl { get; set; }
    }
    
}
