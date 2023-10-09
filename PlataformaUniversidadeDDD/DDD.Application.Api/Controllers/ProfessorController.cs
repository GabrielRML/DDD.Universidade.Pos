using DDD.Domain.PosGraduacaoContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        readonly IProfessorRepository _professorRepository;

        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        [HttpGet]
        public ActionResult<List<Professor>> Get(string? nome = null)
        {
            return Ok(_professorRepository.GetProfessors(nome));
        }

        [HttpGet("{id}")]
        public ActionResult<Professor> GetById(int id)
        {
            return Ok(_professorRepository.GetProfessorById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Professor> CreateProfessor(Professor professor)
        {
            _professorRepository.InsertProfessor(professor);
            return CreatedAtAction(nameof(GetById), new { id = professor.UserId }, professor);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Professor professor)
        {
            try
            {
                if (professor == null)
                    return NotFound();

                _professorRepository.UpdateProfessor(professor);
                return Ok("Professor Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] Professor professor)
        {
            try
            {
                if (professor == null)
                    return NotFound();

                _professorRepository.DeleteProfessor(professor);
                return Ok("Professor Removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
