using DDD.Domain.PosGraduacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IMatriculaRepository
    {
        public List<Matricula> GetMatriculas();
        public Matricula GetMatriculaById(int id);
        public Matricula InsertMatricula(int idAluno, int idSeqCurso);
        public void UpdateMatricula(Matricula matricula);
        public void DeleteMatricula(Matricula matricula);
    }
}
