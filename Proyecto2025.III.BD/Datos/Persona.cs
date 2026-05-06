using Proyecto2025.III.BD.Datos;
using Proyecto2025.III.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto2025.III.BD.Datos
{
    public class Persona : BaseEntity
    {
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "Teléfono es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public required string Telefono { get; set; }

        [Required(ErrorMessage = "DNI es obligatorio")]
        public int DNI { get; set; }

        [Required(ErrorMessage = "Mail es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        public required string Mail { get; set; }

        [Required(ErrorMessage = "Indicar si pagó la Tasa de Justicia o los Aportes")]
        public bool TasaJusticia_Aportes { get; set; }

        // Relaciones de navegación
        public List<CasoPersona>? CasoPersonas { get; set; }
      
    }
}

