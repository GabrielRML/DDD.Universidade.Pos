using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PosGraduacao
{
    public class Pesquisador : User
    {
        [StringLength(50)]
        public string Titulacao { get; set; }
        public List<ProjetoPesquisador>? ProjetoPesquisador { get; set; }

    }
}
