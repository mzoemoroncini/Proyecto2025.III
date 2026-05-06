using Proyecto2025.III.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Proyecto2025.III.Shared.DTO
{
    public class CasoPersonaDTO
    {
        [Required]
        public int PersonaId { get; set; }

        [Required]
        public int CasoId { get; set; }

    }
}
