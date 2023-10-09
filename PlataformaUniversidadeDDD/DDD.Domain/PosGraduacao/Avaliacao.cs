using DDD.Domain.PosGraduacaoContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PosGraduacao
{
    public class Avaliacao
    {
        public int AvaliacaoId { get; set; }
        [StringLength(50)]
        public string AvaliacaoName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal Nota { get; set; }
        public DateTime DataAvaliacao { get;}
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        public int SeqCursoId { get; set; }
        public SeqCurso? SeqCurso { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina? Disciplina { get; set; }
        public int Ano { get; set; }
        public int Etapa { get; set; }
    }
}
