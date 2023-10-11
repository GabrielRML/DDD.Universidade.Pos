using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PosGraduacao
{
    public class Grade
    {
        public int SeqCursoId { get; set; }
        public SeqCurso? SeqCurso { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina? Disciplina { get; set; }
    }
}
