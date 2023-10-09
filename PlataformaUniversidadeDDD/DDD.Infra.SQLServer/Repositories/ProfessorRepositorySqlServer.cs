using DDD.Domain.PosGraduacaoContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class ProfessorRepositorySqlServer : IProfessorRepository
    {

        private readonly SqlContext _context;

        public ProfessorRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteProfessor(Professor professor)
        {
            try
            {
                _context.Set<Professor>().Remove(professor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Professor GetProfessorById(int id)
        {
            return _context.Professores.Find(id);
        }

        public List<Professor> GetProfessors(string? nome = null)
        {
            return _context.Professores.Where(p => p.Nome.Contains(nome ?? p.Nome)).ToList();
        }

        public void InsertProfessor(Professor professor)
        {
            try
            {
                _context.Professores.Add(professor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateProfessor(Professor professor)
        {
            try
            {
                _context.Entry(professor).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
