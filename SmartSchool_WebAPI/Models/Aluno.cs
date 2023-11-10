namespace SmartSchool_WebAPI.Models
{
    public class Aluno
    {
        public Aluno()
        {
            AlunosDisciplinas = new List<AlunoDisciplina>();
        }
        public Aluno(int id, string nome, string sobrenome, string telefone)
        {
            this.id = id;
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.telefone = telefone;
        }

        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string telefone { get; set; }
        public IEnumerable<AlunoDisciplina>? AlunosDisciplinas { get; set; }   


    }
}
