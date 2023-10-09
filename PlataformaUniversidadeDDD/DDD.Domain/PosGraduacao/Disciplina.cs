using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PosGraduacao
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        [StringLength(50)]
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public bool Disponivel { get; set; }
        public IList<Grade>? Grade { get; set; }
    }
}
