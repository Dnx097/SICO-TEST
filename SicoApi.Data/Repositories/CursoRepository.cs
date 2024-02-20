using Microsoft.EntityFrameworkCore;
using SicoApi.Data.BD_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Data.Repositories
{
    public class CursoRepository : IGenericRepository<Curso>
    {
        private readonly SicoTestContext _context;
        public CursoRepository(SicoTestContext context) {
            _context = context;
        }

        public async Task<bool> Crear(Curso modelo)
        {
            _context.Cursos.Add(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Editar(Curso modelo)
        {
            _context.Cursos.Update(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(Curso modelo)
        {
            _context.Cursos.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Curso> Obtener(int id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        public async Task<IQueryable<Curso>> ObtenerTodos()
        {
            IQueryable<Curso> queryCursoSQL = _context.Cursos;
            return queryCursoSQL;
        }
    }
}
