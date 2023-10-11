using DDD.Domain.PosGraduacao;
using DDD.Infra.SQLServer;
using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//IOC - Dependency Injection

/* Users */
builder.Services.AddScoped<IAlunoRepository, AlunoRepositorySqlServer>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepositorySqlServer>();

/* Pesquisa */
builder.Services.AddScoped<IPesquisadorRepository, PesquisadorRepositorySqlServer>();
builder.Services.AddScoped<IProjetoRepository, ProjetoRepositorySqlServer>();
builder.Services.AddScoped<IPublicacaoCientificaRepository, PublicacaoCientificaRepositorySqlServer>();
builder.Services.AddScoped<IProjetoPesquisadorRepository, ProjetoPesquisadorRepositorySqlServer>();

/* Didatico */
builder.Services.AddScoped<ICursoRepository, CursoRepositorySqlServer>();
builder.Services.AddScoped<ISeqCursoRepository, SeqCursoRepositorySqlServer>();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepositorySqlServer>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepositorySqlServer>();
builder.Services.AddScoped<IGradeRepository, GradeRepositorySqlServer>();

/* Dependecia do Banco */
builder.Services.AddScoped<SqlContext, SqlContext>();

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
