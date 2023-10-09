using DDD.Domain.PosGraduacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface ICursoRepository
    {
        public List<Curso> GetCursos();
        public Curso GetCursoById(int id);
        public void InsertCurso(Curso curso);
        public void UpdateCurso(Curso curso);
        public void DeleteCurso(Curso curso);
    }
}
