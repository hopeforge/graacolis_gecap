using System.Collections.Generic;

namespace BackEnd.Domain
{
    public class Empresa
    {
        protected Empresa()
        {
            
        }
        public Empresa(string nomeEmpresa, string cNPJ, string nomeUsuario, string senha)
        {
            NomeEmpresa = nomeEmpresa;
            CNPJ = cNPJ;
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string CNPJ { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public List<Desafio> ListaDesafio { get; set; }
    }
}