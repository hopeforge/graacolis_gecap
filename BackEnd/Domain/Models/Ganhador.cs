namespace BackEnd.Domain
{
    public class Ganhador
    {
        protected Ganhador()
        {
            
        }
        public Ganhador(string nome, string linkedinUrl, Usuario usuario, Premiacao premiacao, Desafio desafio)

        {
            Nome = nome;
            LinkedinUrl = linkedinUrl;
            Usuario = usuario;
            Premiacao = premiacao;
            Desafio = desafio;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string LinkedinUrl { get; set; }
        public Desafio Desafio { get; set; }
        public Premiacao Premiacao { get; set; }
        public Usuario Usuario { get; set; }
    }
}