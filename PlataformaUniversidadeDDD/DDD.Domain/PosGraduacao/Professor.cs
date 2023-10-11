using DDD.Domain.PosGraduacao;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PosGraduacaoContext
{
	public class Professor: User
	{
        [StringLength(50)]
        public string Titulacao { get; set; }
    }
}

