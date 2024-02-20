using Microsoft.EntityFrameworkCore;
using SicoApi.Data.BD_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Data.Repositories
{
    public class EstudianteXCursoRepository : IGenericRepository<EstudianteXCurso>
    {
        private readonly SicoTestContext _context;
        public EstudianteXCursoRepository(SicoTestContext context)
        {
            _context = context;
        }
        public async Task<bool> Crear(EstudianteXCurso modelo)
        {
            _context.EstudianteXCursos.Add(modelo);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Editar(EstudianteXCurso modelo)
        {
            _context.EstudianteXCursos.Update(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(EstudianteXCurso modelo)
        {
            _context.EstudianteXCursos.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<EstudianteXCurso> Obtener(int id)
        {
            return await _context.EstudianteXCursos.FindAsync(id);
        }

        public async Task<IQueryable<EstudianteXCurso>> ObtenerTodos()
        {
            IQueryable<EstudianteXCurso> queryCursoSQL = _context.EstudianteXCursos.Include(x => x.IdEstudianteNavigation).Include(x => x.IdCursoNavigation);
            return queryCursoSQL;
        }
    }
}
