using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SicoApi.Services.Interface;

namespace SicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("SicoApiRules")]
    public class CursoController : ControllerBase
    {
        private readonly ICurso _ContextCurso;
        public CursoController(ICurso contextCurso)
        {
            _ContextCurso = contextCurso;
        }

        [HttpGet]
        [Route("ListadoCursos")]
        public async Task<IActionResult> GetListadoCursos()
        {
            try
            {
                var ListCurso = await _ContextCurso.ObtenerTodos();
                return Ok(ListCurso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("BuscarPorCurso")]
        public async Task<IActionResult> GetListadoCurso(int id)
        {
            try
            {
                var ListCurso = await _ContextCurso.Obtener(id);
                return Ok(ListCurso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
