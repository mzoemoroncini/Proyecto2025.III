using Proyecto2025.III.BD.Datos.Entity;
using Proyecto2025.III.Shared.ENUM;
using System.ComponentModel.DataAnnotations;

namespace Proyecto2025.III.BD.Datos
{
    public class Caso : BaseEntity
    {
        [Required(ErrorMessage = "El numero de expediente es obligatorio")]
        public int NumeroExpediente { get; set; }

        [DataType(DataType.Date)]
        public DateOnly FechaInicio { get; set; }

        public EstadoCaso Estado { get; set; }
        public string? Descripcion { get; set; }

        public TipoCaso Tipo { get; set; }

        // navegacion 
        public List<CasoPersona>? CasoPersonas { get; set; }
        public List<Documentacion>? Documentacions { get; set; }
    }
}