using Proyecto2025.III.BD.Datos;
using Proyecto2025.III.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.III.Repositorio.Repositorios
{
    public class CasoPersonaRepositorio : Repositorio<CasoPersona>, ICasoPersonaRepositorio
        {
            private readonly AppDBContext context;

        public CasoPersonaRepositorio(AppDBContext context) : base(context)
        {
            this.context = context;
        }
    }
}

