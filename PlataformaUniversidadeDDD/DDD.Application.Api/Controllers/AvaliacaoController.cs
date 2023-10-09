using DDD.Domain.PosGraduacao;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Universidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        [HttpGet]
        public ActionResult<List<Avaliacao>> Get()
        {
            return Ok(_avaliacaoRepository.GetAvaliacao());
        }

        [HttpGet("{id}")]
        public ActionResult<Avaliacao> GetById(int id)
        {
            return Ok(_avaliacaoRepository.GetAvaliacaoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Avaliacao> CreateAvaliacao(Avaliacao avaliacao)
        {
            _avaliacaoRepository.InsertAvaliacao(avaliacao);
            return CreatedAtAction(nameof(GetById), new { id = avaliacao.AvaliacaoId }, avaliacao);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Avaliacao avaliacao)
        {
            try
            {
                if (avaliacao == null)
                    return NotFound();

                _avaliacaoRepository.UpdateAvaliacao(avaliacao);
                return Ok("Avaliação Atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] Avaliacao avaliacao)
        {
            try
            {
                if (avaliacao == null)
                    return NotFound();

                _avaliacaoRepository.DeleteAvaliacao(avaliacao);
                return Ok("Avaliação Removida com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
