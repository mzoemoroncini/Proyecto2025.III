using Proyecto2025.III.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.III.BD.Datos.Entity
{
    public interface IBaseEntity
    {
            int Id { get; set; }
            ENUMEstadoRegistro EstadoRegistro { get; set; }
    }

}
