using SicoApi.Data.BD_Context;
using SicoApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Services.Service
{
    public class EstudianteService : Interface.IEstudiante
    {
        private readonly IGenericRepository<Estudiante> _EstudianteRepo;
        public EstudianteService(IGenericRepository<Estudiante> EstudianteRepo)
        {
            _EstudianteRepo = EstudianteRepo;
        }
        public async Task<bool> Editar(Estudiante modelo)
        {
            return await _EstudianteRepo.Editar(modelo);
        }

        public async Task<bool> Eliminar(Estudiante modelo)
        {
            return await _EstudianteRepo.Eliminar(modelo);
        }

        public async Task<Estudiante> Obtener(int? id, string nombre, string correo)
        {
            IQueryable<Estudiante> ListEstudent = await _EstudianteRepo.ObtenerTodos().ConfigureAwait(false);

            Estudiante Estudiante = new Estudiante();

            if (!id.HasValue && string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(correo))
                return Estudiante;


           var estudent=  ListEstudent.FirstOrDefault(x => 
            x.IdEstudiante == (!id.HasValue ? null : id!.Value)
            || x.NombresEstudiante!.ToUpper().Trim()
            .Equals((string.IsNullOrEmpty(nombre)? null : nombre.ToUpper().Trim()))
            || x.Correo!.ToUpper().Trim()
            .Equals((string.IsNullOrEmpty(correo) ? null : correo.ToUpper().Trim()))
            );

            if (estudent != null) Estudiante = estudent;



            return Estudiante;
        }

        public async Task<IQueryable<Estudiante>> ObtenerTodos()
        {
            return await _EstudianteRepo.ObtenerTodos();
        }
    }
}
