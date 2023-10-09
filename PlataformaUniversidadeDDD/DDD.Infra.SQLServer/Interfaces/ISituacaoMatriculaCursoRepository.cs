using DDD.Domain.PosGraduacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface ISituacaoMatriculaRepository
    {
        public List<SituacaoMatricula> GetAll();
        public SituacaoMatricula GetById(int situacao);
        public void Insert(SituacaoMatricula situacao);
        public void Update(SituacaoMatricula situacao);
        public void Delete(SituacaoMatricula situacao);
    }
}
