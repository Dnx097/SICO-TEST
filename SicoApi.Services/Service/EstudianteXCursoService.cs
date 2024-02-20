using Microsoft.EntityFrameworkCore;
using SicoApi.Data.BD_Context;
using SicoApi.Data.Repositories;
using SicoApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Services.Service
{
    public class EstudianteXCursoService : Interface.IEstudianteXCurso
    {
        private readonly IGenericRepository<EstudianteXCurso> _EstudianteXCursoRepo;
        private readonly IGenericRepository<Estudiante> _EstudianteRepo;
        private readonly IGenericRepository<Curso> _CursoRepo;
        public EstudianteXCursoService(IGenericRepository<EstudianteXCurso> EstudianteXCursoRepo,
            IGenericRepository<Estudiante> EstudianteRepo,
            IGenericRepository<Curso> CursoRepo)
        {
            _EstudianteXCursoRepo = EstudianteXCursoRepo;
            _EstudianteRepo = EstudianteRepo;
            _CursoRepo = CursoRepo;
        }
        public async Task<bool> Crear(EstudianteXCurso modelo)
        {
            return await _EstudianteXCursoRepo.Crear(modelo);
            
        }
        public async Task<bool> Editar(EstudianteXCurso modelo)
        {
            return await _EstudianteXCursoRepo.Editar(modelo);
        }

        public async Task<bool> EliminarEstudiante(int? id)
        {
            try
            {
                IQueryable<EstudianteXCurso> Query = await _EstudianteXCursoRepo.ObtenerTodos();
                EstudianteXCurso estudianteXCurso = Query.FirstOrDefault(x => x.IdEstudianteXCurso.Equals(id));

                if (estudianteXCurso != null)
                {
                    _EstudianteXCursoRepo.Eliminar(estudianteXCurso);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            
        }

        public async Task<IQueryable<EstudianteXCurso>> Obtener(int? id)
        {
            IQueryable<EstudianteXCurso> ListEstudianteXCurso = await _EstudianteXCursoRepo.ObtenerTodos().ConfigureAwait(false);

                
                
            if (!id.HasValue)
            {
                return null;

            }

            IQueryable<EstudianteXCurso> EstudianteXCurso = ListEstudianteXCurso.Where(x => x.IdEstudiante == (!id.HasValue ? null : id!.Value));

            return EstudianteXCurso;
        }

        public async Task<IQueryable<EstudianteXCurso>> ObtenerTodos()
        {
            return await _EstudianteXCursoRepo.ObtenerTodos();
        }

    }
}
