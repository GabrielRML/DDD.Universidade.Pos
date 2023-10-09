using DDD.Domain.PosGraduacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface ISeqCursoRepository
    {
        public List<SeqCurso> GetAll(int? seqCurso = null, int? curso = null);
        public List<SeqCurso> GetBetweenDate(DateTime date);
        public SeqCurso GetById(int seqCursoId);
        public void Insert(SeqCurso seqCurso);
        public void Update(SeqCurso seqCurso);
        public void Delete(SeqCurso seqCurso);
    }
}
