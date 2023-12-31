﻿using DDD.Domain.PosGraduacao;
using DDD.Domain.PosGraduacaoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IPesquisadorRepository
    {
        public List<Pesquisador> GetAll(string? nome = null);
        public Pesquisador GetById(int pesquisadorId);
        public void Insert(Pesquisador pesquisador);
        public void Update(Pesquisador pesquisador);
        public void Delete(Pesquisador pesquisador);
    }
}
