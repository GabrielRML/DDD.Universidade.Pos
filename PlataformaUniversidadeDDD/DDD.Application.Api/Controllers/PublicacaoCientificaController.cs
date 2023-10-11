using DDD.Domain.PosGraduacao;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacaoCientificaController : ControllerBase
    {
        readonly IPublicacaoCientificaRepository _publicacaoRepository;

        public PublicacaoCientificaController(IPublicacaoCientificaRepository publicacaoRepository)
        {
            _publicacaoRepository = publicacaoRepository;
        }

        [HttpGet]
        public ActionResult<List<PublicacaoCientifica>> GetAll()
        {
            return Ok(_publicacaoRepository.GetAll());
        }

        [HttpGet("{publicacaoId}")]
        public ActionResult<PublicacaoCientifica> GetById(int publicacaoId)
        {
            return Ok(_publicacaoRepository.GetById(publicacaoId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PublicacaoCientifica> CreateProfessor(PublicacaoCientifica publicacao)
        {
            _publicacaoRepository.Insert(publicacao);
            return CreatedAtAction(nameof(GetById), new { publicacaoId = publicacao.PublicacaoId }, publicacao);
        }

        [HttpPut]
        public ActionResult Put([FromBody] PublicacaoCientifica publicacao)
        {
            try
            {
                if (publicacao == null)
                    return NotFound();

                _publicacaoRepository.Update(publicacao);
                return Ok("Publicaçao Atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] PublicacaoCientifica publicacao)
        {
            try
            {
                if (publicacao == null)
                    return NotFound();

                _publicacaoRepository.Delete(publicacao);
                return Ok("Publicação Removida com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
