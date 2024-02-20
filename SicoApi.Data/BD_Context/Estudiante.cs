using System;
using System.Collections.Generic;

namespace SicoApi.Data.BD_Context;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public string? NombresEstudiante { get; set; }

    public string? ApellidosEstudiante { get; set; }

    public int? Edad { get; set; }

    public long? Telefono { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<EstudianteXCurso> EstudianteXCursos { get; set; } = new List<EstudianteXCurso>();
}
