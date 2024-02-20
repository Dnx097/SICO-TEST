using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Services.DTO
{
    public class EstudianteXCursoDTO
    {
        public int IdEstudianteXCurso { get; set; }
        public int? IdEstudiante { get; set; }
        public int? IdCurso { get; set; }
    }
}
