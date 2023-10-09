using DDD.Domain.PosGraduacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IPublicacaoCientificaRepository
    {
        public List<PublicacaoCientifica> GetPublicacoes();
        public PublicacaoCientifica GetById(int publicacaoId);
        public void InsertPublicacao(PublicacaoCientifica publicacao);
        public void UpdatePublicacao(PublicacaoCientifica publicacao);
        public void DeletePublicacao(PublicacaoCientifica publicacao);
    }
}
