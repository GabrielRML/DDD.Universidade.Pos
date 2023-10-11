using DDD.Domain.PosGraduacao;
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
    public class PesquisadorRepositorySqlServer : IPesquisadorRepository
    {

        private readonly SqlContext _context;

        public PesquisadorRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void Delete(Pesquisador pesquisador)
        {
            try
            {
                _context.Set<Pesquisador>().Remove(pesquisador);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Pesquisador GetById(int pesquisadorId)
        {
            return _context.Pesquisadores.FirstOrDefault(p => p.UserId == pesquisadorId);
        }

        public List<Pesquisador> GetAll(string? nome = null)
        {
            return _context.Pesquisadores.Where(p => p.Nome.Contains(nome ?? p.Nome)).ToList();
        }

        public void Insert(Pesquisador pesquisador)
        {
            try
            {
                _context.Pesquisadores.Add(pesquisador);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Pesquisador pesquisador)
        {
            try
            {
                _context.Entry(pesquisador).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
