using DDD.Domain.PosGraduacao;
using DDD.Domain.PosGraduacaoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IProjetoPesquisadorRepository
    {
        public List<ProjetoPesquisador> GetAll();
        public ProjetoPesquisador GetById(int ProjetoId, int PesquisadorId);
        public void Insert(ProjetoPesquisador projetoPesquisador);
        public void Delete(ProjetoPesquisador projetoPesquisador);
    }
}
