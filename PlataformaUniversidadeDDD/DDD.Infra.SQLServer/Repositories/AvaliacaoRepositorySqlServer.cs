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
    public class AvaliacaoRepositorySqlServer : IAvaliacaoRepository
    {

        private readonly SqlContext _context;

        public AvaliacaoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

       

        public void DeleteAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                _context.Set<Avaliacao>().Remove(avaliacao);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    

        public List<Avaliacao> GetAvaliacao()
        {
            return _context.Avaliacoes.ToList();
        }

        public Avaliacao GetAvaliacaoById(int id)
        {
            return _context.Avaliacoes.Find(id); 
        }

     

        public void InsertAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                _context.Avaliacoes.Add(avaliacao);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                _context.Entry(avaliacao).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }   
}
