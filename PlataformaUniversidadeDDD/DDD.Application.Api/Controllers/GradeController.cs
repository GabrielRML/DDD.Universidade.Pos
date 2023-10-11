using Azure;
using DDD.Domain.PosGraduacao;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        readonly IGradeRepository _gradeRepository;

        public GradeController(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        [HttpGet]
        public ActionResult<List<Grade>> Get()
        {
            return Ok(_gradeRepository.GetGrades());
        }

        [HttpGet("{seqCurso}/{disciplinaId}")]
        public ActionResult<Grade> GetById(int seqCurso, int disciplinaId)
        {
            return Ok(_gradeRepository.GetGradeById(seqCurso, disciplinaId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateAluno(Grade grade)
        {
            _gradeRepository.InsertGrade(grade);
            return CreatedAtAction(nameof(GetById), new { seqCurso = grade.SeqCursoId, disciplinaId = grade.DisciplinaId }, grade);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Grade grade)
        {
            try
            {
                if (grade == null)
                    return NotFound();

                _gradeRepository.UpdateGrade(grade);
                return Ok("Grade Atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] Grade grade)
        {
            try
            {
                //return NotFound();

                _gradeRepository.DeleteGrade(grade);
                return Ok("Grade Removida com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
