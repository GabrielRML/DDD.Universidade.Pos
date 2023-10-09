using DDD.Domain.PosGraduacao;
using DDD.Domain.PosGraduacaoContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {

        //https://balta.io/blog/ef-crud
        //https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversidadeDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Matricula>().HasKey(g => new { g.SeqCursoId, g.AlunoId, g.MatriculaId });

            modelBuilder.Entity<Grade>().HasKey(g => new { g.SeqCursoId, g.DisciplinaId, g.Ano, g.Etapa });

            modelBuilder.Entity<Avaliacao>().HasKey(a => new { a.AvaliacaoId, a.AlunoId, a.ProfessorId, a.SeqCursoId, a.DisciplinaId, a.Ano, a.Etapa });

            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<User>().HasIndex(u => u.Cpf).IsUnique();
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Pesquisador>().ToTable("Pesquisador");
            //https://learn.microsoft.com/pt-br/ef/core/modeling/inheritance
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<SituacaoMatricula> SituacaoMatricula { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Pesquisador> Pesquisadores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<PublicacaoCientifica> PublicacoesCientificas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<SeqCurso> SeqCurso { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
    }
}
