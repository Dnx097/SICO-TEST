using SicoApi.Data.BD_Context;
using SicoApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Services.Service
{
    public class CursoService : Interface.ICurso
    {
        private readonly IGenericRepository<Curso> _cursoRepo;
        public CursoService(IGenericRepository<Curso> cursoRepo) {
            _cursoRepo = cursoRepo;
        }
        public async Task<bool> Editar(Curso modelo)
        {
            return await _cursoRepo.Editar(modelo);
        }

        public async Task<bool> Eliminar(Curso modelo)
        {
            return await _cursoRepo.Eliminar(modelo);
        }

        public async Task<Curso> Obtener(int id)
        {
            return await _cursoRepo.Obtener(id);
        }

        public async Task<IQueryable<Curso>> ObtenerTodos()
        {
            return await _cursoRepo.ObtenerTodos();
        }
    }
}
