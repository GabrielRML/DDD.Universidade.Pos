using DDD.Domain.PosGraduacao;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public ActionResult<List<Aluno>> Get(string? nome = null, string? cpf = null)
        {
            return Ok(_alunoRepository.GetAlunos(nome, cpf));
        }

        [HttpGet("{id}")]
        public ActionResult<Aluno> GetById(int id)
        {
            return Ok(_alunoRepository.GetAlunoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Aluno> CreateAluno(Aluno aluno)
        {
            _alunoRepository.InsertAluno(aluno);
            return CreatedAtAction(nameof(GetById), new { id = aluno.UserId }, aluno);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Aluno aluno)
        {
            try
            {
                if (aluno == null)
                    return NotFound();

                _alunoRepository.UpdateAluno(aluno);
                return Ok("Aluno Atualizado com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] Aluno aluno)
        {
            try
            {
                if (aluno == null)
                    return NotFound();

                _alunoRepository.DeleteAluno(aluno);
                return Ok("Aluno Removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
