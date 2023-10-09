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
    public class SituacaoMatriculaRepositorySqlServer : ISituacaoMatriculaRepository
    {

        private readonly SqlContext _context;

        public SituacaoMatriculaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void Delete(SituacaoMatricula situacao)
        {
            try
            {
                _context.Set<SituacaoMatricula>().Remove(situacao);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SituacaoMatricula GetById(int situacao)
        {
            return _context.SituacaoMatricula.Find(situacao);
        }

        public List<SituacaoMatricula> GetAll()
        {
            return _context.SituacaoMatricula.ToList();
        }

        public void Insert(SituacaoMatricula situacao)
        {
            try
            {
                _context.SituacaoMatricula.Add(situacao);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(SituacaoMatricula situacao)
        {
            try
            {
                _context.Entry(situacao).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
