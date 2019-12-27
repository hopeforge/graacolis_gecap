using System.Collections.Generic;


namespace BackEnd.Domain
{
    public class Premiacao
    {
        protected Premiacao()
        {
            
        }
        public Premiacao(string tipo, int quantidadePremiados)
        {
            Tipo = tipo;
            QuantidadePremiados = quantidadePremiados;
        }

        public int Id { get; set; }
        public string Tipo { get; set; }
        public int QuantidadePremiados { get; set; }
        public int DesafioId { get; set; }
        public Desafio Desafio { get; set; }
        public List<Ganhador> ListaGanhadores { get; set; }
    }
}