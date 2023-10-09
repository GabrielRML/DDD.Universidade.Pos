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

        public void DeletePublicacao(PublicacaoCientifica publicacao)
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
            return _context.PublicacoesCientificas.Include(p => p.Projeto).FirstOrDefault(p => p.PublicacaoId == publicacaoId);
        }

        public List<PublicacaoCientifica> GetPublicacoes()
        {
            return _context.PublicacoesCientificas.Include(p => p.Projeto).ToList();
        }

        public void InsertPublicacao(PublicacaoCientifica publicacao)
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

        public void UpdatePublicacao(PublicacaoCientifica publicacao)
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
