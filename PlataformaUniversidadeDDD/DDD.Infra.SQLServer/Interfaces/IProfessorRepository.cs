using DDD.Domain.PosGraduacaoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IProfessorRepository
    {
        public List<Professor> GetProfessors(string? nome = null);
        public Professor GetProfessorById(int id);
        public void InsertProfessor(Professor professor);
        public void UpdateProfessor(Professor professor);
        public void DeleteProfessor(Professor professor);
    }
}
