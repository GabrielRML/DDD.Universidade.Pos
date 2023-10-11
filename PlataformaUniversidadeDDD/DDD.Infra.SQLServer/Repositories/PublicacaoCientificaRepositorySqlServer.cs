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
    public class PublicacaoCientificaRepositorySqlServer : IPublicacaoCientificaRepository
    {

        private readonly SqlContext _context;

        public PublicacaoCientificaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void Delete(PublicacaoCientifica publicacao)
        {
            try
            {
                _context.Set<PublicacaoCientifica>().Remove(publicacao);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PublicacaoCientifica GetById(int publicacaoId)
        {
            return _context.PublicacoesCientificas.FirstOrDefault(p => p.PublicacaoId == publicacaoId);
        }

        public List<PublicacaoCientifica> GetAll()
        {
            return _context.PublicacoesCientificas.Include(x => x.Projeto).ToList();
        }

        public void Insert(PublicacaoCientifica publicacao)
        {
            try
            {
                _context.PublicacoesCientificas.Add(publicacao);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(PublicacaoCientifica publicacao)
        {
            try
            {
                _context.Entry(publicacao).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
