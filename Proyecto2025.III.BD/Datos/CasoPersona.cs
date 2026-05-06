using Proyecto2025.III.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.III.BD.Datos
{
    public class CasoPersona : BaseEntity
    {
        //fk
        public int PersonaId { get; set; }
        public Persona? Personas { get; set; }
        public int CasoId { get; set; }
        public Caso? Casos { get; set; }

    }
}
