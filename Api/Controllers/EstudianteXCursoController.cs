using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SicoApi.Data.BD_Context;
using SicoApi.Services.DTO;
using SicoApi.Services.Interface;

namespace SicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("SicoApiRules")]
    public class EstudianteXCursoController : ControllerBase
    {
        private readonly IEstudianteXCurso _ContextEstudianteXCurso;
        public EstudianteXCursoController(IEstudianteXCurso contextEstudianteXCursoController)
        {
            _ContextEstudianteXCurso = contextEstudianteXCursoController;
        }

        [HttpGet]
        [Route("ListadoEstudianteXCurso")]
        public async Task<IActionResult> GetListadoEstudianteXCurso()
        {
            try
            {
                var ListEstudianteXCurso = await _ContextEstudianteXCurso.ObtenerTodos();
                return Ok(ListEstudianteXCurso);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("BuscarPorEstudianteXCurso")]
        public async Task<IActionResult> GetListadoEstudiante(int? id)
        {
            try
            {
                var ListEstudentXCurso = await _ContextEstudianteXCurso.Obtener(id);
                return Ok(ListEstudentXCurso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("EliminarEstudianteXCurso")]
        public async Task<IActionResult> DeleteEstudianteXCurso(int? id)
        {
            try
            {
                var ListEstudentXCurso = await _ContextEstudianteXCurso.EliminarEstudiante(id);
                return Ok(ListEstudentXCurso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CrearEstudianteXCurso")]
        public async Task<IActionResult> CrearEstudianteXCurso(EstudianteXCursoDTO estudianteXCursoDTO)
        {
            try
            {
                EstudianteXCurso estudianteXCurso = ConvertirADTOAEntidadCrear(estudianteXCursoDTO);
                var resultado = await _ContextEstudianteXCurso.Crear(estudianteXCurso);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("EditarEstudianteXCurso")]
        public async Task<IActionResult> EditarEstudianteXCurso(EstudianteXCursoDTO estudianteXCursoDTO)
        {
            try
            {
                EstudianteXCurso estudianteXCurso = ConvertirADTOAEntidadEditar(estudianteXCursoDTO);
                var resultado = await _ContextEstudianteXCurso.Editar(estudianteXCurso);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private EstudianteXCurso ConvertirADTOAEntidadCrear(EstudianteXCursoDTO estudianteXCursoDTO)
        {
            return new EstudianteXCurso
            {
                IdEstudiante = estudianteXCursoDTO.IdEstudiante,
                IdCurso = estudianteXCursoDTO.IdCurso
            };
        }

        private EstudianteXCurso ConvertirADTOAEntidadEditar(EstudianteXCursoDTO estudianteXCursoDTO)
        {
            return new EstudianteXCurso
            {
                IdEstudianteXCurso = estudianteXCursoDTO.IdEstudianteXCurso,
                IdEstudiante = estudianteXCursoDTO.IdEstudiante,
                IdCurso = estudianteXCursoDTO.IdCurso
            };
        }
    }
}
