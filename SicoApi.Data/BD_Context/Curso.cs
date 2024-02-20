using System;
using System.Collections.Generic;

namespace SicoApi.Data.BD_Context;

public partial class Curso
{
    public int IdCurso { get; set; }

    public string? NombreCurso { get; set; }

    public string? Dificultad { get; set; }

    public virtual ICollection<EstudianteXCurso> EstudianteXCursos { get; set; } = new List<EstudianteXCurso>();
}
