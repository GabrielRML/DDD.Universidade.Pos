using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PosGraduacao
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string NomeCurso { get; set; }
        public bool Disponivel { get; set; }
        public bool Ead { get; set; }
        public decimal Mensalidade { get; set; }
        public IList<SeqCurso>? SeqCurso { get; set; }

    }
}
