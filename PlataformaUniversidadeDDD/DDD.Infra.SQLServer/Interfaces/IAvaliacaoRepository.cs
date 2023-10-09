using DDD.Domain.PosGraduacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IAvaliacaoRepository
    {
        public List<Avaliacao> GetAvaliacao();
        public Avaliacao GetAvaliacaoById(int id);
        public void InsertAvaliacao(Avaliacao avaliacao);
        public void UpdateAvaliacao(Avaliacao avaliacao);
        public void DeleteAvaliacao(Avaliacao avaliacao);
    }
}
