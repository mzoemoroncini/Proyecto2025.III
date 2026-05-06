using Proyecto2025.III.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.III.Repositorio.Repositorios
{
    public interface IRepositorio<E> where E : class, IBaseEntity
    {
        Task<bool> Existe(int id);
        Task<int> Insert(E entidad);
        Task<List<E>> Select();
        Task<E?> SelectById(int id);
        Task<bool> Update(int id, E entidad);
        Task<bool> Delete(int id);
    }
}
