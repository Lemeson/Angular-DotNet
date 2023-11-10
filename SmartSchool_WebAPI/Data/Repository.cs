using Microsoft.EntityFrameworkCore;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Data
{
    public class Repository : IRepository //herda de IRepository e aqui os métodos definidos em IRepository tomam "vida"
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }//até aqui é obgratorio

        public async Task<Aluno[]> GetAllAlunosAsync(bool includeDisciplina = false) //false é apenas um valor padrão para inicialização
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeDisciplina)
            {
                query = query.Include(pe => pe.AlunosDisciplinas)
                             .ThenInclude(ad => ad.disciplina)
                             .ThenInclude(d => d.professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }
        public async Task<Aluno> GetAlunoAsyncById(int alunoId, bool includeDisciplina)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeDisciplina)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.disciplina)
                             .ThenInclude(d => d.professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.id)
                         .Where(aluno => aluno.id == alunoId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Aluno[]> GetAlunosAsyncByDisciplinaId(int disciplinaId, bool includeDisciplina)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeDisciplina)
            {
                query = query.Include(p => p.AlunosDisciplinas)
                             .ThenInclude(ad => ad.disciplina)
                             .ThenInclude(d => d.professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.id)
                         .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.disciplinaId == disciplinaId));

            return await query.ToArrayAsync();
        }

        public async Task<Professor[]> GetProfessoresAsyncByAlunoId(int alunoId, bool includeDisciplina)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeDisciplina)
            {
                query = query.Include(p => p.disciplinas);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.id)
                         .Where(aluno => aluno.disciplinas.Any(d =>
                            d.AlunosDisciplinas.Any(ad => ad.alunoId == alunoId)));

            return await query.ToArrayAsync();
        }

        public async Task<Professor[]> GetAllProfessoresAsync(bool includeDisciplinas = true)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeDisciplinas)
            {
                query = query.Include(c => c.disciplinas);
            }

            query = query.AsNoTracking()
                         .OrderBy(professor => professor.id);

            return await query.ToArrayAsync();
        }
        public async Task<Professor> GetProfessorAsyncById(int professorId, bool includeDisciplinas = true)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeDisciplinas)
            {
                query = query.Include(pe => pe.disciplinas);
            }

            query = query.AsNoTracking()
                         .OrderBy(professor => professor.id)
                         .Where(professor => professor.id == professorId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
