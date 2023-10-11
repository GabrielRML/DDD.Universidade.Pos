using DDD.Domain.PosGraduacao;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisadorController : ControllerBase
    {
        readonly IPesquisadorRepository _pesquisadorRepository;

        public PesquisadorController(IPesquisadorRepository pesquisadorRepository)
        {
            _pesquisadorRepository = pesquisadorRepository;
        }

        [HttpGet]
        public ActionResult<List<Pesquisador>> Get(string? nome = null)
        {
            return Ok(_pesquisadorRepository.GetAll(nome));
        }

        [HttpGet("{id}")]
        public ActionResult<Pesquisador> GetById(int id)
        {
            return Ok(_pesquisadorRepository.GetById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Pesquisador> CreateProfessor(Pesquisador pesquisador)
        {
            _pesquisadorRepository.Insert(pesquisador);
            return CreatedAtAction(nameof(GetById), new { id = pesquisador.UserId }, pesquisador);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Pesquisador pesquisador)
        {
            try
            {
                if (pesquisador == null)
                    return NotFound();

                _pesquisadorRepository.Update(pesquisador);
                return Ok("Pesquisador Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] Pesquisador pesquisador)
        {
            try
            {
                if (pesquisador == null)
                    return NotFound();

                _pesquisadorRepository.Delete(pesquisador);
                return Ok("Pesquisador Removido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
