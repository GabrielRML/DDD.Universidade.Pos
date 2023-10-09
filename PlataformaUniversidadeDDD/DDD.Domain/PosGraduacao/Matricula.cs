using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PosGraduacao
{
    public class Matricula
    {
        public int MatriculaId { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int SeqCursoId { get; set; }
        public SeqCurso SeqCurso { get; set; }
        public int SituacaoMatriculaId { get; set; }
        public SituacaoMatricula SituacaoMatricula { get; set; }
        public DateTime DataMatricula { get; set; }
    }
}
