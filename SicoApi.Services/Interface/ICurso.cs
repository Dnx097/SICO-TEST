using SicoApi.Data.BD_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Services.Interface
{
    public interface ICurso
    {
        Task<bool> Editar(Curso modelo);
        Task<Curso> Obtener(int id);
        Task<IQueryable<Curso>> ObtenerTodos();
        Task<bool> Eliminar(Curso modelo);
    }
}
