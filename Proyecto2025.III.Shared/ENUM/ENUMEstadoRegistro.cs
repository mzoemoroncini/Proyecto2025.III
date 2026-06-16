using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.III.Shared.ENUM
{
    public enum ENUMEstadoRegistro
    {
        Activo = 1,
        Inactivo = 2,
        Borrado = 3,
        EnGrabacion = 4

    }
    public enum ResultadoOperacionSeguridad
    {
        Exitoso = 1,
        Fallido = 2,
        NoEncontrado = 3,
        SinPermiso = 4
    }
}
