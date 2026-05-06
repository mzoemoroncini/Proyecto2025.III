using Proyecto2025.III.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.III.BD.Datos
{
    public class TipoDocumentacion : BaseEntity
    {
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string Nombre { get; set; }
        // navegacion
        public List<Documentacion>? Documentacions { get; set; }
    }
}
