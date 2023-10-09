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

        public void DeletePesquisador(Pesquisador pesquisador)
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

        public List<Pesquisador> GetPesquisadores()
        {
            return _context.Pesquisadores.ToList();
        }

        public void InsertPesquisador(Pesquisador pesquisador)
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

        public void UpdatePesquisador(Pesquisador pesquisador)
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
