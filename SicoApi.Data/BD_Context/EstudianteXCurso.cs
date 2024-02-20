using System;
using System.Collections.Generic;

namespace SicoApi.Data.BD_Context;

public partial class EstudianteXCurso
{
    public int IdEstudianteXCurso { get; set; }

    public int? IdEstudiante { get; set; }

    public int? IdCurso { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; }

    public virtual Estudiante? IdEstudianteNavigation { get; set; }
}
