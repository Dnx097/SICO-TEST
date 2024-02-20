using SicoApi.Data.BD_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SicoApi.Services.Interface
{
    public interface IEstudianteXCurso
    {
        Task<bool> Editar(EstudianteXCurso modelo);
        Task<IQueryable <EstudianteXCurso>> Obtener(int? id);
        Task<IQueryable<EstudianteXCurso>> ObtenerTodos();
        Task<bool> EliminarEstudiante(int? id);
        Task<bool> Crear(EstudianteXCurso modelo);
    }
}
