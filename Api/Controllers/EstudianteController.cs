using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SicoApi.Services.Interface;

namespace SicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("SicoApiRules")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudiante _ContextEstuden;

        public EstudianteController(IEstudiante contextEstuden)
        {
            _ContextEstuden = contextEstuden;
        }


        [HttpGet]
        [Route("ListadoTotal")]

        public async Task<IActionResult> GetListadoEstudiante()
        {
            try
            {
                var ListEstudent = await _ContextEstuden.ObtenerTodos();
                return Ok(ListEstudent);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("BuscarPorEstudiante")]
        public async Task<IActionResult> GetListadoEstudiante(int?id, string? nombre, string? correo)
        {
            try
            {

                var ListEstudent = await _ContextEstuden.Obtener(id, nombre, correo);


                return Ok(ListEstudent);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



    }
}
