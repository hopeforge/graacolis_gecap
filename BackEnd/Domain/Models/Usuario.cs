using System.Collections.Generic;
using System.Text;

namespace BackEnd.Domain {
public class Usuario {
    protected Usuario()
    {
        
    }
        public Usuario(string nomeUsuario, string senha)
        {
            NomeUsuario = nomeUsuario;
            Senha = CriptografarSenha(senha);
    
        }
        public int Id { get; set; }
        public string NomeUsuario { get; private set; }
        public string Senha { get; private set; }
        public List<DesafioUsuario> ListaDesafio { get; set; }
        public bool AutenticarUsuario(string nomeUsuario, string senha)
        {
            if (NomeUsuario == nomeUsuario && Senha == CriptografarSenha(senha))
                return true;

            return false;
        }

        private string CriptografarSenha(string senhaRecebida)
        {
            if (string.IsNullOrEmpty(senhaRecebida)) return "";
            var senha = (senhaRecebida += "|5d131cca-f6c0-40c0-bb43-6e12989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(senha));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));
            return sbString.ToString();
        }        
    }
}