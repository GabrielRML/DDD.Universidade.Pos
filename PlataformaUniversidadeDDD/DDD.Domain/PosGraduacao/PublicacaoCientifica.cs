using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PosGraduacao
{
    public class PublicacaoCientifica
    {
        [Key]
        public int PublicacaoId { get; set; }
        [StringLength(50)]
        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        [StringLength(50)]
        public string Conteudo { get; set; }
        public string Link { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
