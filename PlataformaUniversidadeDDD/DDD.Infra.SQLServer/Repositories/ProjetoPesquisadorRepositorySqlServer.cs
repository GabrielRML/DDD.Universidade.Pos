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
    public class ProjetoPesquisadorRepositorySqlServer : IProjetoPesquisadorRepository
    {

        private readonly SqlContext _context;

        public ProjetoPesquisadorRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void Delete(ProjetoPesquisador projetoPesquisador)
        {
            try
            {
                _context.Set<ProjetoPesquisador>().Remove(projetoPesquisador);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProjetoPesquisador> GetAll()
        {
            return _context.ProjetoPesquisador.Include(x => x.Projeto).Include(y => y.Pesquisador).ToList();
        }

        public ProjetoPesquisador GetById(int ProjetoId, int PesquisadorId)
        {
            return _context.ProjetoPesquisador.Include(x => x.Projeto).Include(y => y.Pesquisador).FirstOrDefault(x => x.ProjetoId == ProjetoId && x.PesquisadorId == PesquisadorId);
        }

        public void Insert(ProjetoPesquisador projetoPesquisador)
        {
            try
            {
                _context.ProjetoPesquisador.Add(projetoPesquisador);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
