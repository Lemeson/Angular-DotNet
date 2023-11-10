﻿using Microsoft.EntityFrameworkCore;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Data
{
     public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { } //da opsções de CRUD -- obrigatório
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new { AD.alunoId, AD.disciplinaId });

            builder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, "Lauro"),
                    new Professor(2, "Roberto"),
                    new Professor(3, "Ronaldo"),
                    new Professor(4, "Rodrigo"),
                    new Professor(5, "Alexandre"),
                });

            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", 1),
                    new Disciplina(2, "Física", 2),
                    new Disciplina(3, "Português", 3),
                    new Disciplina(4, "Inglês", 4),
                    new Disciplina(5, "Programação", 5)
                });

            builder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, "Marta", "Kent", "33225555"),
                    new Aluno(2, "Paula", "Isabela", "3354288"),
                    new Aluno(3, "Laura", "Antonia", "55668899"),
                    new Aluno(4, "Luiza", "Maria", "6565659"),
                    new Aluno(5, "Lucas", "Machado", "565685415"),
                    new Aluno(6, "Pedro", "Alvares", "456454545"),
                    new Aluno(7, "Paulo", "José", "9874512")
                });

            builder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new AlunoDisciplina() {alunoId = 1, disciplinaId = 2 },
                    new AlunoDisciplina() {alunoId = 1, disciplinaId = 4 },
                    new AlunoDisciplina() {alunoId = 1, disciplinaId = 5 },
                    new AlunoDisciplina() {alunoId = 2, disciplinaId = 1 },
                    new AlunoDisciplina() {alunoId = 2, disciplinaId = 2 },
                    new AlunoDisciplina() {alunoId = 2, disciplinaId = 5 },
                    new AlunoDisciplina() {alunoId = 3, disciplinaId = 1 },
                    new AlunoDisciplina() {alunoId = 3, disciplinaId = 2 },
                    new AlunoDisciplina() {alunoId = 3, disciplinaId = 3 },
                    new AlunoDisciplina() {alunoId = 4, disciplinaId = 1 },
                    new AlunoDisciplina() {alunoId = 4, disciplinaId = 4 },
                    new AlunoDisciplina() {alunoId = 4, disciplinaId = 5 },
                    new AlunoDisciplina() {alunoId = 5, disciplinaId = 4 },
                    new AlunoDisciplina() {alunoId = 5, disciplinaId = 5 },
                    new AlunoDisciplina() {alunoId = 6, disciplinaId = 1 },
                    new AlunoDisciplina() {alunoId = 6, disciplinaId = 2 },
                    new AlunoDisciplina() {alunoId = 6, disciplinaId = 3 },
                    new AlunoDisciplina() {alunoId = 6, disciplinaId = 4 },
                    new AlunoDisciplina() {alunoId = 7, disciplinaId = 1 },
                    new AlunoDisciplina() {alunoId = 7, disciplinaId = 2 },
                    new AlunoDisciplina() {alunoId = 7, disciplinaId = 3 },
                    new AlunoDisciplina() {alunoId = 7, disciplinaId = 4 },
                    new AlunoDisciplina() {alunoId = 7, disciplinaId = 5 }
                });
        }
    }
}