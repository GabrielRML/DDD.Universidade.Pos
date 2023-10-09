using DDD.Domain.PicContext;
using DDD.Domain.PosGraduacao;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Universidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeqCursoController : ControllerBase
    {
        readonly ISeqCursoRepository _seqCursoRepository;

        public SeqCursoController(ISeqCursoRepository seqCursoRepository)
        {
            _seqCursoRepository = seqCursoRepository;
        }

        [HttpGet]
        public ActionResult<List<SeqCurso>> Get(int? seqCurso = null, int? cursoId = null)
        {
            var list = _seqCursoRepository.GetAll(seqCurso, cursoId);
            return list.Any() ? Ok(list) : BadRequest("Nenhum resultado encontrado.");
        }

        [HttpGet("GetBetweenDate")]
        public ActionResult<List<SeqCurso>> GetBetweenDate(DateTime date)
        {
            return Ok(_seqCursoRepository.GetBetweenDate(date));
        }

        [HttpGet("{seqCursoId}", Name = "GetById")]
        public ActionResult<SeqCurso> GetById(int seqCursoId)
        {
            return Ok(_seqCursoRepository.GetById(seqCursoId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<SeqCurso> CreateSeqCurso(SeqCurso seqCurso)
        {
            _seqCursoRepository.Insert(seqCurso);
            return CreatedAtAction(nameof(GetById), new { seqCursoId = seqCurso.SeqCursoId }, seqCurso);
        }

        [HttpPut]
        public ActionResult Put([FromBody] SeqCurso seqCurso)
        {
            try
            {
                if (seqCurso == null)
                    return NotFound();

                _seqCursoRepository.Update(seqCurso);
                return Ok($"Sequência de Curso - {seqCurso.SeqCursoId} Atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] SeqCurso seqCurso)
        {
            try
            {
                if (seqCurso == null)
                    return NotFound();

                _seqCursoRepository.Delete(seqCurso);
                return Ok("Sequência de Curso Removida com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
