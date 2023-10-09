using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PosGraduacao
{
    public class SituacaoMatricula
    {
        [Key]
        public int SituacaoId { get; set; }
        [StringLength(30)]
        public string NomeSituacao { get; set; }
    }
}
