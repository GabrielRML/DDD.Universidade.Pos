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
    public class CursoRepositorySqlServer : ICursoRepository
    {
        private readonly SqlContext _context;

        public CursoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public Curso GetCursoById(int id)
        {
            return _context.Cursos.FirstOrDefault(x => x.CursoId == id);
        }

        public List<Curso> GetCursos()
        {
            return _context.Cursos.ToList();
        }

        public void InsertCurso(Curso curso)
        {
            try
            {
                _context.Cursos.Add(curso);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCurso(Curso curso)
        {
            try
            {
                _context.Entry(curso).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCurso(Curso curso)
        {
            try
            {
                _context.Set<Curso>().Remove(curso);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
