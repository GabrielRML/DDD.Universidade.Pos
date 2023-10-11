using DDD.Domain.PosGraduacao;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Universidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoPesquisadorController : ControllerBase
    {
        readonly IProjetoPesquisadorRepository _projetoPesquisadorRepository;

        public ProjetoPesquisadorController(IProjetoPesquisadorRepository projetoPesquisadorRepository)
        {
            _projetoPesquisadorRepository = projetoPesquisadorRepository;
        }

        [HttpGet]
        public ActionResult<List<ProjetoPesquisador>> Get()
        {
            return Ok(_projetoPesquisadorRepository.GetAll());
        }

        [HttpGet("{ProjetoId}/{PesquisadorId}")]
        public ActionResult<Grade> GetById(int ProjetoId, int PesquisadorId)
        {
            return Ok(_projetoPesquisadorRepository.GetById(ProjetoId, PesquisadorId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateProjeto(ProjetoPesquisador projetoPesquisador)
        {
            _projetoPesquisadorRepository.Insert(projetoPesquisador);
            return CreatedAtAction(nameof(GetById), new { ProjetoId = projetoPesquisador.ProjetoId, PesquisadorId = projetoPesquisador.PesquisadorId }, projetoPesquisador);
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] ProjetoPesquisador projetoPesquisador)
        {
            try
            {
                if (projetoPesquisador == null)
                    return NotFound();

                _projetoPesquisadorRepository.Delete(projetoPesquisador);
                return Ok("Projeto/Pesquisador Removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
