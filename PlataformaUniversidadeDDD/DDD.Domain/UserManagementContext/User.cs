using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.UserManagementContext
{
    public abstract class User
    {
        public int UserId { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(11)]
        public string Cpf { get; set; }
        [Required]
        public string NomeUser { get; set; }
        [Required]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
