using DDD.Domain.PosGraduacao;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : Controller
    {
        readonly ICursoRepository _cursoRepository;

        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<Curso>> Get()
        {
            return Ok(_cursoRepository.GetCursos());
        }

        [HttpGet("{id}")]
        public ActionResult<Curso> GetById(int id)
        {
            return Ok(_cursoRepository.GetCursoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Curso> CreateCurso(Curso curso)
        {
            _cursoRepository.InsertCurso(curso);
            return CreatedAtAction(nameof(GetById), new { id = curso.CursoId }, curso);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Curso curso)
        {
            try
            {
                if (curso == null)
                    return NotFound();

                _cursoRepository.UpdateCurso(curso);
                return Ok("Curso Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Curso curso)
        {
            try
            {
                if (curso == null)
                    return NotFound();

                _cursoRepository.DeleteCurso(curso);
                return Ok("Curso Removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
