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
    public class SeqCursoRepositorySqlServer : ISeqCursoRepository
    {

        private readonly SqlContext _context;

        public SeqCursoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void Delete(SeqCurso seqCurso)
        {
            try
            {
                _context.Set<SeqCurso>().Remove(seqCurso);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SeqCurso GetById(int seqCursoId)
        {
            return _context.SeqCurso.Find(seqCursoId);
        }

        public List<SeqCurso> GetAll(int? seqCurso = null, int? curso = null)
        {
            return _context.SeqCurso.Include(s => s.Curso)
                        .Where(s => s.SeqCursoId == (seqCurso ?? s.SeqCursoId) && s.CursoId == (curso ?? s.CursoId)).ToList();
        }

        public List<SeqCurso> GetBetweenDate(DateTime date)
        {
            return _context.SeqCurso.Where(s => date.Date >= s.DataInicial.Date && date.Date <= s.DataFinal.Date).ToList();
        }

        public void Insert(SeqCurso seqCurso)
        {
            try
            {
                _context.SeqCurso.Add(seqCurso);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(SeqCurso seqCurso)
        {
            try
            {
                _context.Entry(seqCurso).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
