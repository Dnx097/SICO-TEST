using SicoApi.Data.BD_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Services.Interface
{
    public interface IEstudiante
    {
        Task<bool> Editar(Estudiante modelo);
        Task<Estudiante> Obtener(int? id, string nombre, string correo);
        Task<IQueryable<Estudiante>> ObtenerTodos();
        Task<bool> Eliminar(Estudiante modelo);
    }
}
