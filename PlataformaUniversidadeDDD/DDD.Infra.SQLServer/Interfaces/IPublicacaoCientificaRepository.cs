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
        public List<PublicacaoCientifica> GetAll();
        public PublicacaoCientifica GetById(int publicacaoId);
        public void Insert(PublicacaoCientifica publicacao);
        public void Update(PublicacaoCientifica publicacao);
        public void Delete(PublicacaoCientifica publicacao);
    }
}
