using Microsoft.EntityFrameworkCore;
using SicoApi.Data.BD_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Data.Repositories
{
    public class EstudianteRepository : IGenericRepository<Estudiante>
    {
        private readonly SicoTestContext _context;
        public EstudianteRepository(SicoTestContext context)
        {
            _context = context;
        }

        public async Task<bool> Crear(Estudiante modelo)
        {
            _context.Estudiantes.Add(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Editar(Estudiante modelo)
        {
            _context.Estudiantes.Update(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(Estudiante modelo)
        {
            _context.Estudiantes.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Estudiante> Obtener(int id)
        {
            return await _context.Estudiantes.FindAsync(id);
        }

        public async Task<IQueryable<Estudiante>> ObtenerTodos()
        {
            IQueryable<Estudiante> queryCursoSQL = _context.Estudiantes;
            return queryCursoSQL;
        }
    }
}
