using DDD.Domain.PosGraduacao;
using DDD.Infra.SQLServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class MatriculaRepositorySqlServer : IMatriculaRepository
    {
        private readonly SqlContext _context;

        public MatriculaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }


        public void DeleteMatricula(Matricula matricula)
        {
            try
            {
                _context.Set<Matricula>().Remove(matricula);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Matricula GetMatriculaById(int id)
        {
            return _context.Matriculas.FirstOrDefault(x => x.MatriculaId == id);
        }

        public List<Matricula> GetMatriculas()
        {
            return _context.Matriculas.ToList();
        }

        public Matricula InsertMatricula(int idAluno, int idSeqCurso)
        {

            try
            {
                var aluno = _context.Alunos.Find(idAluno);
                var seqCurso = _context.SeqCurso.Find(idSeqCurso);

                var matricula = new Matricula
                {
                    Aluno = aluno,
                    SeqCurso = seqCurso
                };

                _context.Add(matricula);
                _context.SaveChanges();

                return matricula;

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

        }

        public void UpdateMatricula(Matricula matricula)
        {
            throw new NotImplementedException();
        }
    }
}
