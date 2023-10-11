using DDD.Domain.PosGraduacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IGradeRepository
    {
        public List<Grade> GetGrades();
        public Grade GetGradeById(int seqCurso, int disciplinaId);
        public void InsertGrade(Grade grade);
        public void UpdateGrade(Grade grade);
        public void DeleteGrade(Grade grade);
    }
}
