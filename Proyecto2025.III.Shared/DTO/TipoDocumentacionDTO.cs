using Proyecto2025.III.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.III.Shared.DTO
{
    public class TipoDocumentacionDTO
    {
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public required string Nombre { get; set; }
    }
}
