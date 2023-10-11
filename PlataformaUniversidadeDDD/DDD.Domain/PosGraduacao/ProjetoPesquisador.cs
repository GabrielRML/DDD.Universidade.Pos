using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PosGraduacao
{
    public class ProjetoPesquisador
    {
        public int ProjetoId { get; set; }
        public Projeto? Projeto { get; set; }
        public int PesquisadorId { get; set; }
        public Pesquisador? Pesquisador { get; set; }
    }
}
