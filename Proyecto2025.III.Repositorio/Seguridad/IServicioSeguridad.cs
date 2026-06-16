using Proyecto2025.III.Shared.DTO;
using Proyecto2025.III.Shared.ENUM;
namespace Proyecto2025.III.Repositorio.Seguridad;

public interface IServicioSeguridad
{
    Task<ResultadoOperacionSeguridad> HacerAdmin(UsuarioDTO entidad);
    Task<ResultadoOperacionSeguridad> RemoverAdmin(string email);
    Task<List<UsuarioDTO>> ObtenerUsuarios();
}
