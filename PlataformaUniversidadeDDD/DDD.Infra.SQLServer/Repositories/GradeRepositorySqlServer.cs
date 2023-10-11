using DDD.Domain.PosGraduacao;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class GradeRepositorySqlServer : IGradeRepository
    {

        private readonly SqlContext _context;

        public GradeRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public Grade GetGradeById(int seqCurso, int disciplinaId)
        {
            var grade = _context.Grade.FirstOrDefault(g => g.SeqCursoId == seqCurso && g.DisciplinaId == disciplinaId);
            return grade;
        }

        public List<Grade> GetGrades()
        {
            var grades = _context.Grade.Include(g => g.SeqCurso).Include(g => g.Disciplina).ToList();
            return grades;
        }

        public void InsertGrade(Grade grade)
        {

            try
            {
                var seqCurso = _context.SeqCurso.FirstOrDefault(i => i.SeqCursoId == grade.SeqCursoId);
                var disciplina = _context.Disciplinas.FirstOrDefault(i => i.DisciplinaId == grade.DisciplinaId);

                grade.SeqCurso = seqCurso;
                grade.Disciplina = disciplina;

                _context.Add(grade);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }
        }

        public void UpdateGrade(Grade grade)
        {
            try
            {
                _context.Entry(grade).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteGrade(Grade grade)
        {
            try
            {
                _context.Set<Grade>().Remove(grade);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
