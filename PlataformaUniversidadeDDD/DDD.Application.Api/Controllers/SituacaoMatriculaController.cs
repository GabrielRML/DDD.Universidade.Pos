using DDD.Domain.PosGraduacao;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Universidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SituacaoMatriculaController : ControllerBase
    {
        readonly ISituacaoMatriculaRepository _situacaoRepository;

        public SituacaoMatriculaController(ISituacaoMatriculaRepository situacaoRepository)
        {
            _situacaoRepository = situacaoRepository;
        }

        [HttpGet]
        public ActionResult<List<SituacaoMatricula>> Get()
        {
            return Ok(_situacaoRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<SituacaoMatricula> GetById(int situacaoId)
        {
            return Ok(_situacaoRepository.GetById(situacaoId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<SituacaoMatricula> CreateProjeto(SituacaoMatricula situacao)
        {
            _situacaoRepository.Insert(situacao);
            return CreatedAtAction(nameof(GetById), new { id = situacao.SituacaoId }, situacao);
        }

        [HttpPut]
        public ActionResult Put([FromBody] SituacaoMatricula situacao)
        {
            try
            {
                if (situacao == null)
                    return NotFound();

                _situacaoRepository.Update(situacao);
                return Ok("Situação de Matricula Atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] SituacaoMatricula situacao)
        {
            try
            {
                if (situacao == null)
                    return NotFound();

                _situacaoRepository.Delete(situacao);
                return Ok("Situação de Matricula Removida com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
