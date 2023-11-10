using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebAPI.Data;
using SmartSchool_WebAPI.Models;
using System.Data;

namespace SmartSchool_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository repo;

        public ProfessorController(IRepository repo)  //maneira de fazer o aluno conversar com BD
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.repo.GetAllProfessoresAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");

            }
        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> GetByProfessorId(int ProfessorId)
        {
            try
            {
                var result = await this.repo.GetProfessorAsyncById(ProfessorId, true);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");

            }
        }

        [HttpGet("ByAlunoId/{alunoId}")]
        public async Task<IActionResult> GetByDisciplinaId(int alunoId)
        {
            try
            {
                var result = await this.repo.GetProfessoresAsyncByAlunoId(alunoId, true);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");

            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        {
            try
            {
                this.repo.Add(model);

                if (await this.repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{professorId}")]
        public async Task<IActionResult> put(int professorId, Professor model)
        {
            try
            {
                var professor = await this.repo.GetProfessorAsyncById(professorId, false);
                if (professor == null) return NotFound();

                this.repo.Update(model);

                if (await this.repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{professorId}")]
        public async Task<IActionResult> delete(int professorId)
        {
            try
            {
                var professor = await this.repo.GetProfessorAsyncById(professorId, false);
                if (professor == null) return NotFound();

                this.repo.Delete(professor);

                if (await this.repo.SaveChangesAsync())
                {
                    return Ok("Deletado");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}
