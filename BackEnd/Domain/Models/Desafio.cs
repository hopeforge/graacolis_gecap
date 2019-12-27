using System;
using System.Collections.Generic;


namespace BackEnd.Domain {
public class Desafio{
    protected Desafio()
    {
    }
    public Desafio(string nomeDesafio, string descricao, string etapas, DateTime dataInicio, DateTime dataFinal, Premiacao premiacao)
    {
        NomeDesafio = nomeDesafio;
        Descricao = descricao;
        Etapas = etapas;
        DataInicio = dataInicio;
        DataFinal = dataFinal;
        Premiacao = premiacao;
    }

    public int Id { get; set; }
    public string NomeDesafio { get; set; }
    public string Descricao { get; set; }
    public string Etapas { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFinal { get; set; }
    public int PremiacaoId { get; set; }
    public Premiacao Premiacao {get; set;}
    public List<DesafioUsuario> ListaParticipantes { get; set; }
    public List<Ganhador> ListaGanhadores { get; set; }
    public Empresa Empresa { get; set; }

    // antes de adicionar participante preciso verificar se ele já esta inscrito neste desafio
    public void AdicionarParticipante(DesafioUsuario usuario){
        ListaParticipantes.Add(usuario);
    }
}
}