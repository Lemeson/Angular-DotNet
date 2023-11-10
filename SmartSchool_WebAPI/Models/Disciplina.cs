namespace SmartSchool_WebAPI.Models
{
    public class Disciplina
    {
        public Disciplina()
        {
            
        }

        public Disciplina(int id, string nome, int professorId) //, Professor professor
        {
            this.id = id;
            this.nome = nome;
            this.professorId = professorId;
            //this.professor = professor;
        }

        public int id { get; set; }
        public string nome { get; set; }
        public int professorId { get; set; }
        public Professor professor { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }

    }
}
