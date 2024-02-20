using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SicoApi.Data.BD_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Data.Repositories
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<bool> Crear(TEntityModel modelo);
        Task<bool> Editar(TEntityModel modelo);
        Task<TEntityModel> Obtener(int id);
        Task<IQueryable<TEntityModel>> ObtenerTodos();
        Task<bool> Eliminar(TEntityModel modelo);
    }
}
